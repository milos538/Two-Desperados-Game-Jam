using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSpecs : MonoBehaviour
{

    public int m_health = 100;
    public TextMeshProUGUI text;
    public GameObject m_playerRagdoll;
    private void Update()
    {
        text.SetText(m_health.ToString());
    }
    public void gotHurt(int damage){
        m_health -= damage;
        if (m_health <= 0) dead();
    }

    void dead()
    {
        GameObject gem = (GameObject)Instantiate(m_playerRagdoll);
        gem.transform.position = transform.position;
        foreach (Transform child in transform){
            GameObject.Destroy(child.gameObject);
        }
    }
}
