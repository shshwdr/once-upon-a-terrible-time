using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pause()
    {
        Utils.Pause = !Utils.Pause;
        if (Utils.Pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("on trigger enter " + collision);
        //friend
        if (collision.gameObject.layer == 14)
        {
            //get buff type
            HumanBuff.BuffType bufftype = collision.GetComponent<HumanBuff>().buffType;
            Utils.getBuff(bufftype);
        }
        //enemy
        else if(collision.gameObject.layer == 12)
        {
            //game end
            //Utils.gameOverDele();
            //Utils.isGameOver = true;
            Destroy(collision.gameObject);
        }
        //Destroy(collision.gameObject);
    }
}
