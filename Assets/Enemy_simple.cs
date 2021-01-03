using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_simple : MonoBehaviour
{
    int health = 1;
    bool isDead = false;
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
    }

    public void die()
    {
        Destroy(gameObject);
    }
    public void pause()
    {
        
    }
}
