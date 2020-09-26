using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SvenskerSpawn : MonoBehaviour
{
    [Header("Player")]
    [Tooltip("Player GameObject's tag")]
    [SerializeField] private string playerTag; 

    [Header("Svensker")]
    [SerializeField] private GameObject svenskerPrefab;
    [SerializeField] private Svensker[] svenskere;

    private void OnTriggerEnter(Collider other) {
        if(svenskere.Length == 0)
        {
            Debug.Log("No svenskere in this spawner :"+ this.gameObject);
            return;
        }

        if(other.tag == playerTag){
            for(int i = 0; i < svenskere.Length; i++){
                //spawn
                GameObject s = Instantiate(svenskerPrefab, svenskere[i].spawnPosition.position, Quaternion.identity);
                
                //setup
                SvenskerMovement sm = s.GetComponent<SvenskerMovement>();
                SvenskerDø sd = s.GetComponent<SvenskerDø>();

                if(svenskere[i].flag == null){
                    Debug.Log("Hide");
                    sm.SetDestination(svenskere[i].goal, svenskere[i].timeBeforeRun, true);
                }
                else
                {
                    sm.SetDestination(svenskere[i].flag.transform, svenskere[i].timeBeforeRun, false);
                    Debug.Log("Flag");
                    sd.currentFlag = svenskere[i].flag.GetComponent<Flag>();
                }
            }
        }
        
        Destroy(this.gameObject, 1);
    }
}

[System.Serializable]
public struct Svensker
{
    public Transform spawnPosition;
    public GameObject flag;
    public Transform goal;
    public float timeBeforeRun;
}
