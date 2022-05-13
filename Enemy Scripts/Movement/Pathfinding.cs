using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private float aggressionRadius;
    private GameObject target;
    private GameObject[] idlePathingPositions;
    private Vector3 idlePos;
    private float distanceFromPlayer;
    private int randomIdlePathing, idleTime;
    private bool idlePathing;

    void Awake()
    {
        idlePathingPositions = GameObject.FindGameObjectsWithTag("IdlePathingPosition");
        target = GameObject.FindGameObjectWithTag("Player");
        idlePathing = true;
    }

    void Update() { EnemyAggressionRadius(); }

    void EnemyAggressionRadius()
    {
        distanceFromPlayer = Vector3.Distance(enemy.transform.position, target.transform.position);
        if (distanceFromPlayer <= aggressionRadius) { PathToPlayer(); }
        else { IdlePathing(); }
    }

    void PathToPlayer()
    {
        enemy.SetDestination(target.transform.position);
    }

    void IdlePathing()
    {
        if (idlePathing)
        {
            idleTime = Random.Range(0, 5);
            randomIdlePathing = Random.Range(0, idlePathingPositions.Length);
            idlePos = idlePathingPositions[randomIdlePathing].transform.position;
            idlePathing = false;
        }
        else
        {
            enemy.SetDestination(idlePos);
            if (enemy.transform.position.x == idlePos.x) { StartCoroutine(RandomIdle()); }
        }
    }

    IEnumerator RandomIdle()
    {
        yield return new WaitForSeconds(idleTime);
        idlePathing = true;
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(enemy.transform.position, aggressionRadius);
    }*/
}

