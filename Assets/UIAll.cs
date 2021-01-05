using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class UIAll : MonoBehaviour
{
    public GameObject Restart;
    // Start is called before the first frame update
    void Start()
    {
        Restart.SetActive(false);
        print(Restart + " restart");
        Utils.gameOverDele += GameOver;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void HumanDie()
    {
        Utils.HumanKilled += 1;
    }

    public void GameOver()
    {
        Debug.Log("game over");
        Restart.SetActive(true);
        Time.timeScale = 0;
        Utils.isGameOver = true;
    }

     public void RestartButton()
    {

        Restart.SetActive(false);
        DialogueManager.StopConversation();
        Utils.MonsterKilled = 0;
        Utils.HumanKilled = 0;
        StartCoroutine(test());
        //Application.LoadLevel(Application.loadedLevel); 
    }

    public IEnumerator test()
    {

        yield return new WaitForSeconds(0.3f);

        DialogueManager.ResetDatabase();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Utils.isGameOver = false;
        Time.timeScale = 1;
    }


}
