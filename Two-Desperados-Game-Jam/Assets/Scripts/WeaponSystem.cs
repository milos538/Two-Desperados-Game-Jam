using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponSystem : MonoBehaviour{

    // Podaci o oruzju
    public int m_damage;
    public int m_magazineSize, m_bulletsPerTap;
    private int m_bulletsLeft, m_bulletsShot;

    public float m_timeBetweenTwoBullets, m_spread;
    public float m_range, m_reloadTime, m_timeBetweenShootings;

    public bool m_allowedButtonHold;
    private bool m_shooting, m_readyToShoot, m_reloading;
    public TextMeshProUGUI m_bulletText;

    // Reference
    public Camera m_camera;
    public Transform m_attackPoint;
    public RaycastHit m_rayHit;
    public LayerMask m_whatIsEnemy;

    // Efekti
    public GameObject m_bulletHoleGraphic;
    public ParticleSystem m_muzzleFlash;
    public AudioSource m_firingSound;
    private void Start(){
        m_firingSound = GetComponent<AudioSource>();
    }
    private void Update(){
        MyInput();
        m_bulletText.SetText(m_bulletsLeft + " / " + m_magazineSize);
    }
    private void Awake(){
        m_bulletsLeft = m_magazineSize;
        m_readyToShoot = true;
    }
    private void MyInput(){
        if(m_allowedButtonHold) m_shooting = Input.GetKey(KeyCode.Mouse0);
        else m_shooting = Input.GetKeyDown(KeyCode.Mouse0);
        
        if(Input.GetKeyDown(KeyCode.R) && m_bulletsLeft < m_magazineSize && !m_reloading) reload();

        if (m_readyToShoot && m_shooting && !m_reloading && m_bulletsLeft > 0){
            m_firingSound.Play();

            m_bulletsShot = m_bulletsPerTap;
            shoot();
        }
    }

    private void reload(){
        m_reloading = true;
        Invoke("reloadFinished", m_reloadTime);
    }
    private void resetShot(){
        m_readyToShoot = true;
    }
    private void shoot(){
        m_muzzleFlash.Play();
        m_readyToShoot = false;
        float x = Random.Range(-m_spread, m_spread);
        float y = Random.Range(-m_spread, m_spread);

        Vector3 direction = m_camera.transform.forward + new Vector3(x, y, 0);

        if (Physics.Raycast(m_camera.transform.position, direction, out m_rayHit, m_range, m_whatIsEnemy)){
            Debug.Log(m_rayHit.collider.name);
            if (m_rayHit.collider.CompareTag("Enemy")){

                Debug.Log("Enemy pogodjen");
                // radnja ako je enemy
                // rayHit.collider.GetComponent<ShootingAi>().TakeDamage(damage);
            }
        }
        GameObject impactObject = Instantiate(m_bulletHoleGraphic, m_rayHit.point, Quaternion.Euler(0, 180, 0));
        Destroy(impactObject, 1f);
        --m_bulletsLeft;
        --m_bulletsShot;
        Invoke("resetShot", m_timeBetweenTwoBullets);
        if (m_bulletsShot > 0 && m_bulletsLeft > 0) Invoke("shoot", m_timeBetweenTwoBullets);
    }
    private void reloadFinished(){
        m_bulletsLeft = m_magazineSize;
        m_reloading = false;
    }
}
