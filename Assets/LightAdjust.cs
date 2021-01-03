using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LightAdjust : MonoBehaviour
{
    public ZippyLights2D degree_light_depth;
    public ZippyLights2D degree_light_simple;

    public ZippyLights2D degree_light_shadow;

    // Start is called before the first frame update
    void Start()
    {
        Utils.getBuff += BuffLight;
        DOTween.Init();
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

    public void ChangeDegree(float degree)
    {
        float origin_degree = degree_light_depth.degrees;
        degree = Mathf.Min(origin_degree + degree, 360);
        TweenLight(degree_light_depth, origin_degree, degree);

        TweenLight(degree_light_simple, origin_degree, degree);

        TweenLight(degree_light_shadow, origin_degree, degree);

    }

    void TweenLight(ZippyLights2D light, float origin_degree,float degree)
    {
        DOTween.To(x => light.degrees = x, origin_degree, degree, 1).SetUpdate(true);

    }
}
