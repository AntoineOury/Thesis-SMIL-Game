using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{

    public Slider timerSlider;
    
    //how long is the time set to
    public float sliderTimer;
    
    public bool stopTimer = false;

    public void Start()
    {
        timerSlider.maxValue = sliderTimer;
        timerSlider.value = sliderTimer;

        //starts timer when the game starts
        //can be added anywhere in the code, when other logic is added
        StartTimer();
    }


    public void StartTimer()
    {
        StartCoroutine(StartTheTimer());
    }

    IEnumerator StartTheTimer()
    {
        while (stopTimer == false)
        {
            sliderTimer -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if (sliderTimer <= 0)
            {
                stopTimer = true;
            }

            if (stopTimer == false)
            {
                timerSlider.value = sliderTimer;
            }
        }
    }
    
    public void StopTimer()
    {
        stopTimer = true;
    }
}
