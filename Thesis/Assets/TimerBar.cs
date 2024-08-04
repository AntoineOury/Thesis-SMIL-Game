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
    }

    // private Coroutine countdownCOroutine;

    // public void SetMaxTime(int time)
    // {
    //     timerSlider.maxValue = time;
    //     timerSlider.value = time;
    // }
    //
    // public void SetTime(int time)
    // {
    //     timerSlider.value = time;
    // }
}
