﻿using System.Collections;
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

    [SerializeField] SvenskerSpawn[] hallSpawners;
[SerializeField] SvenskerSpawn[] kitchenSpawners;
[SerializeField] SvenskerSpawn[] bathroomSpawners;
[SerializeField] SvenskerSpawn[] livingroomSpawners;
    [SerializeField] DoorStruct[] door;

    public int currentKills;
    int totalEnemies;
    [SerializeField] GameObject endScreen = null;
    bool hasWon = false;

    private void Start() {

        for (int i = 0; i < door.Length; i++)
        {
            totalEnemies += door[i].killsToUnlock;
        }
        totalEnemies += 15;

        Reset();    
    }

    private void Reset() {
        currentKills = 0;
        UpdateUI();
    }

    public void AddKill(){
        currentKills++;
        foreach(DoorStruct d in door){
            if(d.killsToUnlock == currentKills)
            {
                d.doorToOpen.RemoveLock();
            }

        }

        if(currentKills >= totalEnemies && !hasWon)
        {
            hasWon = true;
            Instantiate(endScreen);
        }
        UpdateUI();
    }



    public void WasHidden(){
            
        if(CutsceneManager.instance.running == false)
        {
            if(currentKills < door[0].killsToUnlock)
            {
                hallSpawners[Random.Range(0, hallSpawners.Length)].StartSpawning();
                Debug.Log("Hidden to spawn");
            }
            else if(currentKills < door[1].killsToUnlock)
            {
                kitchenSpawners[Random.Range(0, kitchenSpawners.Length)].StartSpawning();
                Debug.Log("Hidden to spawn");
            }
            else if(currentKills < door[2].killsToUnlock)
            {
                bathroomSpawners[Random.Range(0, bathroomSpawners.Length)].StartSpawning();
                Debug.Log("Hidden to spawn");
            }
            else
            {
                livingroomSpawners[Random.Range(0, livingroomSpawners.Length)].StartSpawning();
                Debug.Log("Hidden to spawn");
            }
        }

    }

    public void UpdateUI()
    {
        foreach (DoorStruct d in door)
        {
            int killsLeft = d.killsToUnlock - currentKills;

            if (killsLeft <= 0)
            {
                d.display.text = d.killsToUnlock.ToString() + " / " + d.killsToUnlock.ToString();
                d.display.color = Color.green;
            }
            else
            {
                d.display.text = currentKills.ToString() + " / " + d.killsToUnlock.ToString();
                d.display.color = Color.yellow;
            }
        }
        
    }

}

[System.Serializable]
public struct DoorStruct
{
    public int killsToUnlock;
    public Door doorToOpen;
    public TextMeshProUGUI display;

}