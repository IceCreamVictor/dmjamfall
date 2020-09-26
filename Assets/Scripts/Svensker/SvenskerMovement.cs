using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(SvenskerDø))]
public class SvenskerMovement : MonoBehaviour
{
    float timeBeforeRun;
    
    public Transform goal;
    [SerializeField] private float destinationReachedTreshold = 0.35f;

    //References
    private SvenskerDø svenskerDø;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        svenskerDø = GetComponent<SvenskerDø>();
    }

    public void SetupSvensker(Transform _goal, float _timeBeforeRun){
        goal = _goal;
        timeBeforeRun = _timeBeforeRun;
        StartCoroutine(StartRun());
    }

    void Update() {

        if(CheckDestinationReached())
            svenskerDø.SvenskaWaMouShindeiru();

    }
  
    IEnumerator StartRun(){
        yield return new WaitForSeconds(timeBeforeRun);
        agent.destination = goal.position;
        }

    bool CheckDestinationReached() {
        float distanceToTarget = Vector3.Distance(transform.position, goal.position);
        
        if(distanceToTarget < destinationReachedTreshold)
            return true;

        return false;
    }
}
