using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SvenskerMovement : MonoBehaviour
{
    //Other
    private bool hideAfter;
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
    [Header("Sound")]
    [SerializeField] AudioSource[] sources = null;
    [SerializeField] float maxTimeBetweenGrunts = 5f;
    [SerializeField] float minTimeBetweenGrunts = 0.5f;

    float currentTimer = 0;
    float timeToReach = 0;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        svenskerDø = GetComponentInChildren<SvenskerDø>();
    }

    void Update() {

        if(currentTimer >= timeToReach)
        {
            currentTimer = 0;
            timeToReach = Random.Range(minTimeBetweenGrunts, maxTimeBetweenGrunts);

            sources[Random.Range(0, sources.Length)].Play();
        }

        currentTimer += Time.deltaTime;      


        if(CheckDestinationReached() && hideAfter)
            svenskerDø.HideSwedish();

        if(CheckDestinationReached() && svenskerDø.currentFlag != null && !svenskerDø.currentFlag.flagMoving){
            svenskerDø.currentFlag.StartFlag(this);
        }
           

    }
  
    public void SetDestination(Transform _destination, float _timeBeforeRun, bool _hideAfter){

        timeBeforeRun = _timeBeforeRun;
        destination = _destination;
        hideAfter = _hideAfter;
        StartCoroutine(StartRun());
    }
    public void SetDestination(Transform _destination, bool _hideAfter){
        destination = _destination;
        hideAfter = _hideAfter;
        StartCoroutine(StartRun());
    }
    IEnumerator StartRun(){

        yield return new WaitForSeconds(timeBeforeRun);
        svenskerAnim.SetBool("Running", true);
        agent.destination = destination.position;
        agent.isStopped = false;
    
    }

    public void CircleRunning(bool b){
        
        svenskerAnim.SetBool("Circle", b);
    }

    bool CheckDestinationReached() {

        float distanceToTarget = Vector3.Distance(this.transform.position, destination.position);
        
        if(distanceToTarget < destinationReachedTreshold){
            return true;
            Debug.Log("hey");
            svenskerAnim.SetBool("Running", false);
            agent.isStopped = true;
        }

        return false;
    }
}
