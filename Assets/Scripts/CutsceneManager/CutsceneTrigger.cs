using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] CutsceneSequence[] cutscenes;


    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            foreach (CutsceneSequence seq in cutscenes)
            {
                CutsceneManager.instance.AddSequence(seq);

            }
        }
    }

    public void PlayCutscene()
    {
        foreach (CutsceneSequence seq in cutscenes)
        {
            CutsceneManager.instance.AddSequence(seq);

        }
    }
}
