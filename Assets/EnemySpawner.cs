using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemyList;
    public float time_min;
    public float time_max;
    public float radius = 2;


    public List<GameObject> humans;
    public List<int> monster_killed;
    List<bool> humanGenerated = new List<bool>(100);
    int currentHuman = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Start a simple timer
        Invoke("SpawnEnemy", 0);

    }

    void SpawnEnemy()
    {
        //CancelInvoke(); // Stop the timer (I don't think you need it, try without)


        //int randomNum = Random.Range(0, totalNumberOfItemsInAvailableCars);
        //Object objTemp = Resources.Load("cars/" + randomNum);
        float angle = Random.Range(0f, 1f) * Mathf.PI*2f;
        Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 1);
        int currentLvelupIndex = 0;
        if (Utils.MonsterKilledTotal >= 5)
        {
            currentLvelupIndex = 1;
        }

        if (Utils.MonsterKilledTotal >= 15)
        {
            currentLvelupIndex = 2;
        }
        Debug.Log(Utils.MonsterKilled +" current currentLvelupIndex " + currentLvelupIndex);
        GameObject enemy = enemyList[Random.Range(0, currentLvelupIndex + 1)];
       
        Instantiate(enemy,newPos,Quaternion.identity);
        // Start a new timer for the next random spawn
        if (Utils.isGameOver)
        {
            return;
        }
        Invoke("SpawnEnemy", Random.Range(time_min, time_max) / (1+Utils.HumanKilled*0.5f));
    }

    private void Update()
    {
        if (currentHuman< monster_killed.Count && currentHuman<humans.Count)
        {

            if (Utils.MonsterKilled >= monster_killed[currentHuman])
            {
                Debug.Log(Utils.MonsterKilled+" has enough kill "+ monster_killed[currentHuman]);
                Utils.MonsterKilled -= monster_killed[currentHuman];
                SpawnHuman();
                currentHuman++;
            }
        }
    }
    void SpawnHuman()
    {
        //CancelInvoke(); // Stop the timer (I don't think you need it, try without)

        string humanName = humans[currentHuman].GetComponent<HumanBuff>().humanName;
        bool isDead = DialogueLua.GetVariable(humanName+"Dead").AsBool;
        if (isDead)
        {
            Debug.Log("well "+ humanName+" has dead already");
            return;
        }
        //int randomNum = Random.Range(0, totalNumberOfItemsInAvailableCars);
        //Object objTemp = Resources.Load("cars/" + randomNum);
        float angle = Random.Range(0f, 1f) * Mathf.PI * 2f;
        Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 1);

        GameObject human_instance = Instantiate(humans[currentHuman], newPos, Quaternion.identity);
        human_instance.GetComponent<HumanBuff>().buffType = HumanBuff.BuffType.Degree;
        // Start a new timer for the next random spawn
        if (Utils.isGameOver)
        {
            return;
        }
    }

}
