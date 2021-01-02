using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIAll : MonoBehaviour
{
    GameObject Restart;
    // Start is called before the first frame update
    void Start()
    {
        Restart = GetComponentInChildren<Transform>(true).gameObject;
        Restart.SetActive(false);
        print(Restart + " restart");
        Utils.gameOverDele += GameOver;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        Debug.Log("game over");
        Restart.SetActive(true);
    }

    public void RestartButton()
    {
        Utils.isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Application.LoadLevel(Application.loadedLevel); 
    }
}
