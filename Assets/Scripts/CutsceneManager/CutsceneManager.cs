using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [Header("Things to disable")]
    [SerializeField] GameObject player;
    


    [Header("Cutscene properties")]
    [SerializeField] private GameObject cutsceneCamera;
    [SerializeField] private Animator fader;
    public CutsceneSequence sequence;

    private float time;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.F))
            EnableCutscene();
    }

    public void EnableCutscene(){
        player.SetActive(false);
        cutsceneCamera.SetActive(true);
       
        StartCoroutine(Cutscene());
    }

    IEnumerator Cutscene(){

        float d = sequence.cameraDuration;
        time = 0;

    
        while(time < d)
        {
            Debug.Log("Time: "+time+ ", duration: "+d);        
            if(sequence.useTurnPoint){
                if(time >= d/2){
                    cutsceneCamera.transform.position = Vector3.Lerp(sequence.camTurnpoint.position, sequence.camEnd.position, (time-d/2) / (d/2));
                    cutsceneCamera.transform.rotation = Quaternion.Lerp(sequence.camTurnpoint.rotation, sequence.camEnd.rotation, (time-d/2) / (d/2));
                }
                else
                {
                cutsceneCamera.transform.position = Vector3.Lerp(sequence.camStart.position, sequence.camTurnpoint.position, time / (d / 2));
                cutsceneCamera.transform.rotation = Quaternion.Lerp(sequence.camStart.rotation, sequence.camTurnpoint.rotation, time / (d / 2));
                }
            }
            else
            {
                cutsceneCamera.transform.position = Vector3.Lerp(sequence.camStart.position, sequence.camEnd.position, time / d);
                cutsceneCamera.transform.rotation = Quaternion.Lerp(sequence.camStart.rotation, sequence.camEnd.rotation, time / d);
            }
            
            
            time += Time.deltaTime;
            yield return null;
        }
        cutsceneCamera.transform.position = sequence.camEnd.position;

        yield return new WaitForSeconds(sequence.duration);
        


        //DISABLE
        fader.Play("ToBlack");
        yield return new WaitForSeconds(0.75f);
        cutsceneCamera.SetActive(false);
        player.SetActive(true);
        fader.Play("FromBlack");

    }

    public void DisableCutscene(){

    }
}

[System.Serializable]
public struct CutsceneSequence
{
    public float duration;
    public float cameraDuration;


    public Transform camStart;
    public Transform camEnd;
    public Transform camTurnpoint;
    public bool useTurnPoint;
}
