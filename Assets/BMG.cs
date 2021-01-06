using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMG : MonoBehaviour
{

    public AudioClip BGM;
    public AudioClip spook;
    public AudioClip playWithMe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {

        //DontDestroyOnLoad(this.gameObject);
    }
    public void playBMG()
    {
        if (GetComponent<AudioSource>().clip.name != BGM.name)
        {
            Debug.Log(GetComponent<AudioSource>().clip);

            Debug.Log(BGM);
            GetComponent<AudioSource>().clip = BGM;
            GetComponent<AudioSource>().Play();
        }
    }
    public void playSpook()
    {

        GetComponent<AudioSource>().clip = spook;
        GetComponent<AudioSource>().Play();
    }

    public void playPlayWithMe()
    {

        GetComponent<AudioSource>().clip = playWithMe;
        GetComponent<AudioSource>().Play();
    }
}
