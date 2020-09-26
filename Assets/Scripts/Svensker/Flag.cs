using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Flag : MonoBehaviour
{
    //FLAG STATE
    [HideInInspector] public bool flagUp;
    private bool flagDown;
    [HideInInspector] public bool flagMoving;
    //////////////////
    

    [Header("Flag animation properties")]
    [SerializeField] GameObject danishFlag;
    [SerializeField] GameObject swedishFlag;
    [SerializeField] Vector3 bottomPos;
    [SerializeField] Vector3 topPos;
    [SerializeField] float duration;
    float time = 0;


    [Header("Svensker properties")]
    [SerializeField] private Transform svenskerHidePos;
    private SvenskerMovement svensker;

    public void StartFlag(SvenskerMovement _svensker){
        StartCoroutine(HejsFlag());
        flagMoving = true;
        svensker = _svensker;
        
        //få svensker til at løbe rundt om flag

    }

    public void StopFlag(){
        StopCoroutine(HejsFlag());
        StopAllCoroutines();
        flagMoving = false;

        //stop svensker i at løbe rundt om flag
    }

    IEnumerator HejsFlag(){
        
        while(time < duration)
        {
            if(danishFlag.activeSelf == true)
                danishFlag.transform.localPosition = Vector3.Lerp(topPos, bottomPos, time / duration);

            if(swedishFlag.activeSelf == true)
                swedishFlag.transform.localPosition = Vector3.Lerp(bottomPos, topPos, time / duration);


            time += Time.deltaTime;
        
            yield return null;
            
            if(!flagDown && time >= duration)
            {
                flagDown = true;
                time = 0;
                swedishFlag.SetActive(true);
                danishFlag.SetActive(false);
            }
        }
        
        svensker.SetDestination(svenskerHidePos, true);
        StopFlag();

    }

}
