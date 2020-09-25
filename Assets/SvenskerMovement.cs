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
    [SerializeField] private float destinationReachedTreshold = 0.35f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetupSvensker(Transform _goal, float _timeBeforeRun){
        goal = _goal;
        timeBeforeRun = _timeBeforeRun;

        StartCoroutine(StartRun());
    }

    void Update() {
        if(CheckDestinationReached()){
            //Display particle system
            Destroy(this.gameObject);
        }

    }
    IEnumerator StartRun(){
        

        yield return new WaitForSeconds(timeBeforeRun);
        agent.destination = goal.position;

    }

    bool CheckDestinationReached() {

        float distanceToTarget = Vector3.Distance(transform.position, goal.position);

        Debug.Log(distanceToTarget);

        if(distanceToTarget < destinationReachedTreshold)
            return true;

        return false;
    }
}
