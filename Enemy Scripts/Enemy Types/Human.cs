using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Human : Enemy
{
    private void Awake()
    {
        navAgent = this.GetComponent<NavMeshAgent>();
        navAgent.speed = speed;
    }

    protected override void Update()
    {
        base.Update();
        navAgent.speed = speed;
    }
}
