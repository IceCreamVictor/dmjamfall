using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetDoor : Interactable
{
    [SerializeField] Animator anim = null;
    bool isOpen = false;
    [SerializeField] bool isFridge = false;

    private void Start()
    {
        function = OpenDoor;
    }

    void OpenDoor()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            if (isFridge)
                AudioManager.instance.Play("FridgeOpen");
            else
                AudioManager.instance.Play("ClosetOpen");
            anim.Play("DoorOpen");
        }
        else
        {
            if (isFridge)
                AudioManager.instance.Play("FridgeClose");
            else
                AudioManager.instance.Play("ClosetClose");
            anim.Play("DoorClose");
        }

        if(!spawned && svensker.spawnPosition != null){
            StartCoroutine(SpawnSvensker());
            spawned = true;
        }
    }


    [Header("Svensker")]
    [SerializeField] Svensker svensker;
    private bool spawned;
    [SerializeField] private float spawnDelay = 2;

    [SerializeField] private GameObject svenskerPrefab;
    [SerializeField] private GameObject smokeBomb;

    IEnumerator SpawnSvensker(){
        yield return new WaitForSeconds(spawnDelay);
        if(svensker.spawnPosition == null)
            Debug.Log("No svenskere in this spawner :"+ this.gameObject);
        
        //spawn
        Instantiate(smokeBomb, svensker.spawnPosition.position, Quaternion.identity);
        GameObject s = Instantiate(svenskerPrefab, svensker.spawnPosition.position, Quaternion.identity);

        //setup
        SvenskerMovement sm = s.GetComponent<SvenskerMovement>();
        SvenskerDø sd = s.GetComponent<SvenskerDø>();

        //give task
        if(svensker.flag == null){
            sm.SetDestination(svensker.goal, svensker.timeBeforeRun, true);
        }
        else
        {
            sm.SetDestination(svensker.flag.transform, svensker.timeBeforeRun, false);
            sd.currentFlag = svensker.flag.GetComponent<Flag>();
        }
    }
}
