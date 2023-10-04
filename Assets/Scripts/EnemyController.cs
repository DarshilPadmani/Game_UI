using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public GameObject Player;
    public float DetectionRadius;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position); 
        if (distance<=DetectionRadius)
        {
            agent.SetDestination(Player.transform.position);
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color= Color.red;
        Gizmos.DrawWireSphere(transform.position, DetectionRadius);
    }
}
