using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SvenskerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    float timeBeforeRun;
    public Transform goal;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetupSvensker(Transform _goal, float _timeBeforeRun){
        goal = _goal;
        timeBeforeRun = _timeBeforeRun;

        StartCoroutine(StartRun());
    }

    IEnumerator StartRun(){
        

        yield return new WaitForSeconds(timeBeforeRun);
        agent.destination = goal.position;

    }
}
