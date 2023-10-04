using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    public enum AISTATE {PATROL,CHASE,ATTACK};

    Animator animator;

    public Transform player;
    public NavMeshAgent enemy;
    public AISTATE enemyState=AISTATE.PATROL;
    float DistanceOffset = 2f;

    public List<Transform> waypoints= new List<Transform>();
    Transform currentWaypoints;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentWaypoints = waypoints[Random.Range(0,waypoints.Count)];
        ChangeState(AISTATE.PATROL);
    }

    public void ChangeState(AISTATE newState)
    {
        StopAllCoroutines();
        enemyState = newState;

        switch (enemyState)
        {
            case AISTATE.PATROL:
                StartCoroutine(PatrolState());
                break;
            case AISTATE.CHASE:
                StartCoroutine(ChaseState());
                break;
            case AISTATE.ATTACK:
                StartCoroutine(AttackState());
                break;
        }
    }
    public IEnumerator PatrolState()
    {
        while (enemyState == AISTATE.PATROL) {
            animator.SetBool("Chase", false);
            enemy.SetDestination(currentWaypoints.position);
            if (Vector3.Distance(transform.position, currentWaypoints.position) < DistanceOffset)
            {
                currentWaypoints = waypoints[Random.Range(0, waypoints.Count)];
            }
            yield return null;
        }
    }
    public IEnumerator ChaseState()
    {
        while(enemyState == AISTATE.CHASE)
        {
            animator.SetBool("Chase",true);
            if (Vector3.Distance(transform.position,player.position)<DistanceOffset)
            {
                ChangeState(AISTATE.ATTACK);
                yield break;
            }
            enemy.SetDestination(player.position);
            yield return null;
        }
    }
    public IEnumerator AttackState()
    {
        while (enemyState==AISTATE.ATTACK)
        {
            if (Vector3.Distance(transform.position,player.position)>DistanceOffset)
            {
                ChangeState(AISTATE.CHASE);
                yield break;
            }

            print("ATTACK");
            //enemy.SetDestination(player.position);
            yield return null;
        }
        yield break;
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) 
        {
            ChangeState(AISTATE.CHASE);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChangeState(AISTATE.PATROL);
        }
    }
}
