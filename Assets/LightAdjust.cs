using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAdjust : MonoBehaviour
{
    public ZippyLights2D degree_light_depth;
    public ZippyLights2D degree_light_simple;

    public ZippyLights2D degree_light_shadow;

    // Start is called before the first frame update
    void Start()
    {
        Utils.getBuff += BuffLight;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BuffLight(HumanBuff.BuffType buffType)
    {
        switch (buffType)
        {
            case HumanBuff.BuffType.Degree:
                ChangeDegree(10);
                break;
            default:
                break;
        }
    }

    void ChangeDegree(float degree)
    {
        degree_light_depth.degrees += degree;
        degree_light_depth.degrees = Mathf.Min(degree_light_depth.degrees, 360);
        degree_light_simple.degrees += degree;
        degree_light_depth.degrees = Mathf.Min(degree_light_simple.degrees, 360);

        degree_light_shadow.degrees += degree;
        degree_light_shadow.degrees = Mathf.Min(degree_light_shadow.degrees, 360);
    }
}
