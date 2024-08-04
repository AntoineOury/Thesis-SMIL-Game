using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PostSODisplay : MonoBehaviour
{
    
    //script written with help from ChatGPT
    
    
    public PostScriptableObject[] postSO;

    public Image postImage;
    public Image accImage;

    // public TMP_Text communNote;


    public Button scrollOn;
    
    private int currentIndex = 0;
    
    public TimerBar timerBarSc; //ref to the TimerBar Script

    void Start()
    {
        if (postSO.Length > 0)
        {
            DisplayPost(postSO[currentIndex]);
        }

        scrollOn.onClick.AddListener(CycleThroughPosts);
        
        //timer ending listener
        timerBarSc.onTimerEnd.AddListener(CycleThroughPosts);
    }

    private void CycleThroughPosts()
    {
        currentIndex = (currentIndex + 1) % postSO.Length;
        DisplayPost(postSO[currentIndex]);
        timerBarSc.RestartTimer(); //restart the timer coroutine
    }
    
    private void DisplayPost(PostScriptableObject postSO){

        postImage.sprite = postSO.postImage;
        accImage.sprite = postSO.accountImage;

        // communNote.text = postSO.communityNote.ToString();
    }
}
