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
    
    //Circles
    bool walkInCircles;


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
        StartCoroutine(WalkInCircles(goal, 0.5f));
        StartCoroutine(StartRun());
    }

    void Update() {

        if(CheckDestinationReached())
            svenskerDø.SvenskaWaMouShindeiru();

    }
   public IEnumerator WalkInCircles(Transform pos, float radius)
   {    
       Debug.Log("He");
        int thetaMax = 8;
        for(int theta = 0; theta <= thetaMax; theta++)
        {
            yield return  new WaitForSeconds(0.2f);
            Vector3 newPosition = new Vector3(pos.position.x + radius * Mathf.Cos(theta), pos.position.y, pos.position.z + radius * Mathf.Sin(theta));
            Debug.Log(newPosition);
            agent.destination = newPosition; 
        }
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
