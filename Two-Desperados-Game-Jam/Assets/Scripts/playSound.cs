using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour{

    private bool m_finishedOnce = false;
    public AudioSource m_sound;
    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player" && !m_finishedOnce)
        {
            m_sound.Play();
            m_finishedOnce = true;
        }

    }
}
