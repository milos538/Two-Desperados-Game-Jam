using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour{

    public int m_damage = 50;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<PlayerSpecs>().gotHurt(m_damage); 
        }
    }
}
