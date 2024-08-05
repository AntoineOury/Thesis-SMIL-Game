using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlagCheckNotes : MonoBehaviour
{
    public PostSODisplay postSODisplay;

    public void CheckFlaggedText(TMP_Text textObject)
    {
        bool isFlagged = postSODisplay.IsNoteFlagged(textObject);
        if (isFlagged)
        {
            Debug.Log("The text object is flagged: " + textObject.text);
            // Perform additional actions for flagged text
        }
        else
        {
            Debug.Log("The text object is not flagged: " + textObject.text);
        }
    }
}