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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("on trigger enter " + collision);
        //friend
        if (collision.gameObject.layer == 14)
        {

        }
        //enemy
        else if(collision.gameObject.layer == 12)
        {
            //game end
            Utils.gameOverDele();
            Utils.isGameOver = true;
        }
    }
}
