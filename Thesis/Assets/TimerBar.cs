using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    
    //code written with help from this tutorial: https://www.youtube.com/watch?v=-dKkAzCrBOY
    //and chatGPT
    public Slider timerSlider;
    public float sliderTimer;

    private float initialSliderTimer;
    private bool stopTimer = false;
    private Coroutine timerCoroutine;

    void Start()
    {
        initialSliderTimer = sliderTimer;
        timerSlider.maxValue = sliderTimer;
        timerSlider.value = sliderTimer;

        // Start the timer when the game starts
        StartTimer();
    }

    public void StartTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }
        stopTimer = false;
        timerCoroutine = StartCoroutine(StartTheTimer());
    }

    IEnumerator StartTheTimer()
    {
        while (!stopTimer)
        {
            sliderTimer -= Time.deltaTime;
            yield return null; // More efficient than WaitForSeconds(0.001f)

            if (sliderTimer <= 0)
            {
                stopTimer = true;
                sliderTimer = 0;
            }

            if (!stopTimer)
            {
                timerSlider.value = sliderTimer;
            }
        }
    }

    public void RestartTimer()
    {
        sliderTimer = initialSliderTimer;
        timerSlider.value = sliderTimer;
        StartTimer();
    }

    public void StopTimer()
    {
        stopTimer = true;
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }
    }
}
