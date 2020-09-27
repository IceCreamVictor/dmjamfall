using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager instance;
    private void Awake() {
        if(instance == null)
            instance = this;
        else
            Debug.LogWarning("more than one instance of progressmanager");
    }


    [SerializeField] DoorStruct[] door;

    int cd; //Current door
    int currentKills;

    private void Start() {
        Reset();    
    }

    private void Reset() {
        currentKills = 0;
        UpdateUI();
    }

    public void AddKill(){
        currentKills++;
        if(door[cd].killsToUnlock == currentKills)
        {
            door[cd].doorToOpen.canOpen = true;
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        int killsLeft = door[cd].killsToUnlock-currentKills;

        if (killsLeft == 0)
            door[cd].display.text = "Åben døren ven. :)";
        else
            //door[cd].display.text = killsLeft.ToString() + " svenskere tilbage";
            door[cd].display.text = currentKills.ToString() + " / " + killsLeft.ToString();
       /* else
            //door[cd].display.text = killsLeft.ToString() + " svensker tilbage";*/
        
    }

}

[System.Serializable]
public struct DoorStruct
{
    public int killsToUnlock;
    public Door doorToOpen;
    public TextMeshProUGUI display;

}