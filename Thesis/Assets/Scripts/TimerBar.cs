// using System.Collections;
// using UnityEngine;
// using UnityEngine.Events;
// using UnityEngine.UI;
//
// public class TimerBar : MonoBehaviour
// {
//     
//     //code written with help from this tutorial: https://www.youtube.com/watch?v=-dKkAzCrBOY
//     //and chatGPT
//     public Slider timerSlider;
//     public float sliderTimer;
//
//     private float initialSliderTimer;
//     private bool stopTimer = false;
//     private Coroutine timerCoroutine;
//
//     public UnityEvent onTimerEnd;
//
//     void Start()
//     {
//         initialSliderTimer = sliderTimer;
//         timerSlider.maxValue = sliderTimer;
//         timerSlider.value = sliderTimer;
//
//         // Start the timer when the game starts
//         StartTimer();
//     }
//
//     public void StartTimer()
//     {
//         if (timerCoroutine != null)
//         {
//             StopCoroutine(timerCoroutine);
//         }
//         stopTimer = false;
//         timerCoroutine = StartCoroutine(StartTheTimer());
//     }
//
//     IEnumerator StartTheTimer()
//     {
//         while (!stopTimer)
//         {
//             sliderTimer -= Time.deltaTime;
//             yield return null;
//
//             if (sliderTimer <= 0)
//             {
//                 stopTimer = true;
//                 sliderTimer = 0;
//                 
//                 onTimerEnd.Invoke(); //Invoked when timer runs out
//             }
//
//             if (!stopTimer)
//             {
//                 timerSlider.value = sliderTimer;
//             }
//         }
//     }
//
//     public void RestartTimer()
//     {
//         sliderTimer = initialSliderTimer;
//         timerSlider.value = sliderTimer;
//         StartTimer();
//     }
//
//     public void StopTimer()
//     {
//         stopTimer = true;
//         if (timerCoroutine != null)
//         {
//             StopCoroutine(timerCoroutine);
//         }
//     }
// }


using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    // Code written with help from this tutorial: https://www.youtube.com/watch?v=-dKkAzCrBOY
    // and ChatGPT
    public Slider timerSlider;
    public float sliderTimer;
    public Color normalColor = Color.green; // Initial fill bar color
    public Color warningColor = Color.red;  // Fill bar color when close to running out

    private float initialSliderTimer;
    private bool stopTimer = false;
    private Coroutine timerCoroutine;

    public UnityEvent onTimerEnd;

    void Start()
    {
        initialSliderTimer = sliderTimer;
        timerSlider.maxValue = sliderTimer;
        timerSlider.value = sliderTimer;
        timerSlider.fillRect.GetComponent<Image>().color = normalColor;

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
            yield return null;

            if (sliderTimer <= 0)
            {
                stopTimer = true;
                sliderTimer = 0;
                
                onTimerEnd.Invoke(); // Invoked when timer runs out
            }

            if (!stopTimer)
            {
                timerSlider.value = sliderTimer;
            }

            // Change the fill bar color when the timer is 5 points away from running out
            if (sliderTimer <= timerSlider.maxValue/4)
            {
                timerSlider.fillRect.GetComponent<Image>().color = warningColor;
            }
            else
            {
                timerSlider.fillRect.GetComponent<Image>().color = normalColor;
            }
        }
    }

    public void RestartTimer()
    {
        sliderTimer = initialSliderTimer;
        timerSlider.value = sliderTimer;
        timerSlider.fillRect.GetComponent<Image>().color = normalColor;
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
