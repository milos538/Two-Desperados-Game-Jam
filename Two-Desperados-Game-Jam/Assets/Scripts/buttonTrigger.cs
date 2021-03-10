using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class buttonTrigger : MonoBehaviour{

    private bool m_isInRange = false;
    public TextMeshProUGUI m_tekst;
    public PlayableDirector m_cutscene;
    public string m_levelName;
    public int m_timeToWaitForCutscene;

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player")
        {
            m_isInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            m_isInRange = false;
        }

    }

    private void Update()
    {
        m_tekst.enabled = m_isInRange;
        if (m_isInRange && Input.GetKeyDown(KeyCode.E))
        {
            m_isInRange = false;
            m_cutscene.Play();
            StartCoroutine(LoadLevelAfterDelay(m_timeToWaitForCutscene));
        }
    }
    IEnumerator LoadLevelAfterDelay(float delay){
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(m_levelName);
    }

}
