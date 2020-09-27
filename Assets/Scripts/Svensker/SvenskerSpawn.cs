using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SvenskerSpawn : MonoBehaviour
{
    private string playerTag = "Killer"; 

    [Header("Svensker")]
    [SerializeField] private GameObject svenskerPrefab;
    [SerializeField] private GameObject smokeBomb;
    [SerializeField] private Svensker[] skere;

    bool used = false;

    private void OnTriggerEnter(Collider other) {
        if(skere.Length == 0)
        {
            Debug.Log("No svenskere in this spawner :"+ this.gameObject);
            return;
        }

        if(other.tag == playerTag && !used)
        {
            StartCoroutine(SpawnSvensker());
        }
    }

    public void StartSpawning(){
        StartCoroutine(SpawnSvensker());
    }

    IEnumerator SpawnSvensker(){

        
        for(int i = 0; i < skere.Length; i++)
        {
            if(skere[i].spawnPosition == null){
                Debug.LogWarning("This spawner's svensker does not have a spawn point");
                break;
            }
            if(skere[i].flag == null && skere[i].goal == null){
                Debug.LogWarning("This spawner's svensker does not have a goal");
                break;
            }

            used = true;
            yield return new WaitForSeconds(skere[i].timeBeforeSpawn);
            
            //spawn
            Instantiate(smokeBomb, skere[i].spawnPosition.position, Quaternion.identity);
            GameObject s = Instantiate(svenskerPrefab, skere[i].spawnPosition.position, Quaternion.identity);

            //setup
            SvenskerMovement sm = s.GetComponent<SvenskerMovement>();
            SvenskerDø sd = s.GetComponentInChildren<SvenskerDø>();

            if(skere[i].flag == null)
                sm.SetDestination(skere[i].goal, skere[i].timeBeforeRun, true);
            else
            {
                sm.SetDestination(skere[i].flag.transform, skere[i].timeBeforeRun, false);
                sd.currentFlag = skere[i].flag.GetComponent<Flag>();
            }
        }
    }
}


[System.Serializable]
public struct Svensker
{
    public Transform spawnPosition;
    public GameObject flag;
    public Transform goal;
    public float timeBeforeRun;
    public float timeBeforeSpawn;
}
