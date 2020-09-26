using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(SvenskerDø))]
public class SvenskerMovement : MonoBehaviour
{
    //Other
    private bool killAfter;
    private float timeBeforeRun;
    ///////////////////////
    
    [Header("Pathfinding")]
    [SerializeField] private float destinationReachedTreshold = 0.5f;
    private Transform destination;

    /////////////////////////////

    //References
    private SvenskerDø svenskerDø;
    NavMeshAgent agent;

    [SerializeField] private Animator svenskerAnim;

    /////////////////////////////

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        svenskerDø = GetComponent<SvenskerDø>();
    }

    void Update() {
/*
        if(CheckDestinationReached() && killAfter)
            svenskerDø.SvenskaWaMouShindeiru();

        if(CheckDestinationReached() && svenskerDø.currentFlag != null && !svenskerDø.currentFlag.flagMoving){
            svenskerDø.currentFlag.StartFlag(this);
        }
  */          

    }
  
    public void SetDestination(Transform _destination, float _timeBeforeRun, bool _killAfter){

        timeBeforeRun = _timeBeforeRun;
        destination = _destination;
        killAfter = _killAfter;
        StartCoroutine(StartRun());
    }
    public void SetDestination(Transform _destination, bool _killAfter){
        destination = _destination;
        killAfter = _killAfter;
        StartCoroutine(StartRun());
    }
    IEnumerator StartRun(){

        yield return new WaitForSeconds(timeBeforeRun);
        svenskerAnim.SetBool("Running", true);
        agent.destination = destination.position;
        agent.isStopped = false;
    
    }

    bool CheckDestinationReached() {

        float distanceToTarget = Vector3.Distance(transform.position, destination.position);
        
        if(distanceToTarget < destinationReachedTreshold){
            return true;
            Debug.Log("hey");
            svenskerAnim.SetBool("Running", false);
            agent.isStopped = true;
        }

        return false;
    }
}
