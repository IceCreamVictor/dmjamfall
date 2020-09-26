using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Flag : MonoBehaviour
{
    Animator flagAnim;  
    [HideInInspector] public bool flagUp;
    private bool flagDown;

    

    [Header("Flag animation properties")]
    [SerializeField] GameObject danishFlag;
    [SerializeField] GameObject swedishFlag;
    [SerializeField] Vector3 bottomPos;
    [SerializeField] Vector3 topPos;
    [SerializeField] float duration;
    float time = 0;
    
    void Start()
    {
        flagAnim = GetComponent<Animator>();
        StartCoroutine(HejsFlag());
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

    }

}
