﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float time_min;
    public float time_max;
    public float radius = 2;


    // Start is called before the first frame update
    void Start()
    {
        // Start a simple timer
        Invoke("SpawnEnemy", 0);
        Debug.Log("Launched");
    }

    void SpawnEnemy()
    {
        CancelInvoke(); // Stop the timer (I don't think you need it, try without)


        //int randomNum = Random.Range(0, totalNumberOfItemsInAvailableCars);
        //Object objTemp = Resources.Load("cars/" + randomNum);
        float angle = Random.Range(0f, 1f) * Mathf.PI*2f;
        Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 1);

        Instantiate(enemy,newPos,Quaternion.identity);
        // Start a new timer for the next random spawn
        if (Utils.isGameOver)
        {
            return;
        }
        Invoke("SpawnEnemy", Random.Range(time_min, time_max));
    }

}