using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyContorller : MonoBehaviour{

    public Animator m_animator;
    public float m_lookRadius = 10f;
    Transform m_target;
    NavMeshAgent m_agent;

    void Start(){
        m_target = GameObject.FindGameObjectWithTag("Player").transform;
        m_agent = GetComponent<NavMeshAgent>();
    }


    void Update(){
        float distance = Vector3.Distance(m_target.position, transform.position);
        if (distance <= m_agent.stoppingDistance){
            faceTarget();
            m_animator.SetBool("Attacking", true);
        }
        else if (distance <= m_lookRadius){
            m_agent.SetDestination(m_target.position);
            m_animator.SetBool("Running", true);
            m_animator.SetBool("Attacking", false);
        }
        else{
            m_animator.SetBool("Running", false);
            m_animator.SetBool("Attacking", false);
        }
    }
    void faceTarget(){
        Vector3 direction = (m_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_lookRadius);
    }
}
