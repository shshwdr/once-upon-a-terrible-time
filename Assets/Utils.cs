using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{

    public static bool Pause;
    public static int MonsterKilled=0;

    public static int MonsterKilledTotal = 0;

    public static int HumanKilled=0;
    public delegate void GameOverDele();
    public static GameOverDele gameOverDele;

    public delegate void GetBuff(HumanBuff.BuffType buffType);
    public static GetBuff getBuff;

    public static bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
