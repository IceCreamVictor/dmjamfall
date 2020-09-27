using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] CutsceneSequence[] cutscenes;
    [SerializeField] bool done;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player" && !done){
            foreach (CutsceneSequence seq in cutscenes)
            {
                CutsceneManager.instance.AddSequence(seq);
            }
                done = true;
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
