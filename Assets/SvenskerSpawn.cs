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
                sm.SetupSvensker(svenskere[i].goal, svenskere[i].timeBeforeRun);
            }
        }
        
        Destroy(this.gameObject, 1);
    }
}

[System.Serializable]
public struct Svensker
{
    public Transform spawnPosition;
    public Transform goal;
    public float timeBeforeRun;
}
