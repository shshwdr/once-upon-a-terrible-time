using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogUtils : MonoBehaviour
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
        
    }
    void OnDisable()
    {
        Debug.Log("PrintOnDisable: script was disabled");
        pause();
    }

    void OnEnable()
    {
        Debug.Log("PrintOnEnable: script was enabled");
        pause();
    }
}
