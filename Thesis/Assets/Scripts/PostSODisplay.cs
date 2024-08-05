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

    public TMP_Text communNote01;
    public TMP_Text communNote02;
    public TMP_Text communNote03;


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

        communNote01.text = postSO.communityNote01;
        communNote02.text = postSO.communityNote02;
        communNote03.text = postSO.communityNote03;
        
    }
    
    public bool IsNoteFlagged(TMP_Text noteText)
    {
        if (noteText == communNote01)
        {
            return postSO[currentIndex].isFlagged01;
        }
        if (noteText == communNote02)
        {
            return postSO[currentIndex].isFlagged02;
        }
        if (noteText == communNote03)
        {
            return postSO[currentIndex].isFlagged03;
        }
        return false;
    }
    
}
