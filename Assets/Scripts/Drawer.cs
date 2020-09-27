using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : Interactable
{
    [SerializeField] Animator anim = null;

    bool isOpen = false;

    void Start()
    {
        function = MoveDrawer;
    }

    void MoveDrawer()
    {
        isOpen = !isOpen;

        if (isOpen) {
            AudioManager.instance.Play("DrawerOpen");
            anim.Play("DrawerOpen");
       
            if(!spawned && svensker.spawnPosition != null)
            {
                StartCoroutine(SpawnSvensker());
                spawned = true; 
            }
        }
        else
        {
            AudioManager.instance.Play("DrawerClose");
            anim.Play("DrawerClose");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Moveable"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.CompareTag("Moveable"))
        {
            if(collision.collider.transform.parent == transform)
            {
                collision.collider.transform.parent = null;
            }
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
