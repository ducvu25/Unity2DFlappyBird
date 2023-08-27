using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayAndNightController : MonoBehaviour
{
    [SerializeField] float[] time;
    [SerializeField] float len = 5f;
    [SerializeField] float sun = 2f;
    [SerializeField] float night = 0.2f;
    [SerializeField] GameObject goLight;
    Light2D light;

    bool isSun;
    float _time;
    
    private void Start()
    {
        light = goLight.GetComponent<Light2D>();
        light.intensity = sun;
        isSun = true;
        SetSunOrNight(isSun);
    }
    void SetSunOrNight(bool isSun)
    {
        if (!isSun)
        {
            _time = time[1];
            transform.GetChild(2).transform.position = transform.GetChild(0).transform.position;
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            _time = time[0];
            transform.GetChild(1).transform.position = transform.GetChild(0).transform.position;
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
        if(_time > 0)
        {
            _time -= deltaTime;
            if(isSun)
            {
                if(light.intensity < sun)
                    light.intensity += (sun - night)*deltaTime/time[0];
                if (transform.GetChild(1).transform.position.x > transform.GetChild(0).transform.position.x - len)
                    transform.GetChild(1).transform.position = transform.GetChild(1).transform.position - new Vector3(len*deltaTime / time[0], 0, 0);
            }
            if(!isSun) { 
                if(light.intensity > night)
                    light.intensity += (night - sun)*deltaTime*2 / time[1];
                if (transform.GetChild(2).transform.position.x > transform.GetChild(0).transform.position.x - len)
                    transform.GetChild(2).transform.position = transform.GetChild(2).transform.position - new Vector3(len*deltaTime / time[1], 0, 0);
            }
        }
        else
        {
            isSun = !isSun;
            SetSunOrNight(isSun);
        } 
    }
}
