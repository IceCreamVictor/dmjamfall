using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class SvenskerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    float timeBeforeRun;
    public Transform goal;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void StartRun(){
        agent.destination = goal.position;
    }

}
