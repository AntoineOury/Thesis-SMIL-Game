using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PostSODisplay : MonoBehaviour
{
    public PostScriptableObject[] postSO;
    
    public Image postImage;
    public Image accImage;

    public TMP_Text communNote01;
    public TMP_Text communNote02;
    public TMP_Text communNote03;

    public Button scrollOn;
    
    public Button button1; // Button reference for communityNote01
    public Button button2; // Button reference for communityNote02
    public Button button3; // Button reference for communityNote03

    private int currentIndex = 0;

    public TimerBar timerBarSc; // Reference to the TimerBar Script

    void Start()
    {
        if (postSO.Length > 0)
        {
            DisplayPost(postSO[currentIndex]);
        }

        button1.onClick.AddListener(() => OnButtonClick(button1.GetComponentInChildren<TMP_Text>().text));
        button2.onClick.AddListener(() => OnButtonClick(button2.GetComponentInChildren<TMP_Text>().text));
        button3.onClick.AddListener(() => OnButtonClick(button3.GetComponentInChildren<TMP_Text>().text));

        //Scroll Button listener
        scrollOn.onClick.AddListener(CycleThroughPosts);
        
        // Timer ending listener
        timerBarSc.onTimerEnd.AddListener(CycleThroughPosts);
    }

    private void CycleThroughPosts()
    {
        currentIndex = (currentIndex + 1) % postSO.Length;
        DisplayPost(postSO[currentIndex]);
        timerBarSc.RestartTimer(); // Restart the timer coroutine
    }

    private void DisplayPost(PostScriptableObject postSO)
    {
        postImage.sprite = postSO.postImage;
        accImage.sprite = postSO.accountImage;

        communNote01.text = postSO.communityNote01;
        communNote02.text = postSO.communityNote02;
        communNote03.text = postSO.communityNote03;

        button1.GetComponentInChildren<TMP_Text>().text = postSO.communityNote01; // Set button text
        button2.GetComponentInChildren<TMP_Text>().text = postSO.communityNote02; // Set button text
        button3.GetComponentInChildren<TMP_Text>().text = postSO.communityNote03; // Set button text
    }

    public bool IsNoteFlagged(string note)
    {
        foreach (var post in postSO)
        {
            if (post.communityNote01 == note && post.isFlagged01) return true;
            if (post.communityNote02 == note && post.isFlagged02) return true;
            if (post.communityNote03 == note && post.isFlagged03) return true;
        }
        return false;
    }

    private void OnButtonClick(string note)
    {
        // Check the flag status of the note when the button is clicked
        bool isFlagged = IsNoteFlagged(note);
        if (isFlagged)
        {
            Debug.Log("Button clicked and the note is flagged: " + note);
            // Perform additional actions for flagged note
        }
        else
        {
            Debug.Log("Button clicked but the note is not flagged: " + note);
        }
    }
}
