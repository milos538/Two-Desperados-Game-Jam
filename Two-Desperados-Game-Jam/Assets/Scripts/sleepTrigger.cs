using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class sleepTrigger : MonoBehaviour{

    private bool m_isInRange = false;
    public TextMeshProUGUI m_tekst;
    public PlayableDirector m_cutscene;

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
        }
    }


}
