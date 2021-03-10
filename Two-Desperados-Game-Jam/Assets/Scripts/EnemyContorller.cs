using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyContorller : MonoBehaviour{

    public int m_health = 15;
    public Animator m_animator;
    public float m_lookRadius = 10f;
    Transform m_target;
    NavMeshAgent m_agent;
    private bool m_alive = true;

    void Start(){
        m_target = GameObject.FindGameObjectWithTag("Player").transform;
        m_agent = GetComponent<NavMeshAgent>();
    }


    void Update(){
        float distance = Vector3.Distance(m_target.position, transform.position);
        if (m_alive) { 
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

    public void dealDamage(int damage)
    {
        m_health -= damage;
        if(m_health <= 0)
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            m_alive = false;
            m_animator.SetBool("Running", false);
            m_animator.SetBool("Attacking", false);
            m_animator.SetBool("Dead", true);
            Destroy(gameObject, 2.5f);
        }
        else
        {
            m_animator.SetBool("Running", false);
            m_animator.SetBool("Attacking", false);
        }
    }
}
