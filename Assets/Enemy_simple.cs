using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_simple : MonoBehaviour
{
    public  int health = 1;
    bool isDead = false;
    public Sprite angrySprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Damage(int d)
    {
        health -= 1;
        if (health <= 0 && !isDead)
        {
            isDead = true;
            die();
        }
        else if (angrySprite)
        {
            GetComponent<SpriteRenderer>().sprite = angrySprite;
        }
    }

    public void die()
    {
        Destroy(gameObject);

    }
    public void pause()
    {
        
    }
}
