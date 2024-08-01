using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PostSODisplay : MonoBehaviour
{
    public PostScriptableObject postSO;

    public Image postImage;
    public Image accImage;

    public TMP_Text communNote;
    void Start()
    {
        postImage.sprite = postSO.postImage;
        accImage.sprite = postSO.accountImage;

        communNote.text = postSO.communityNote.ToString();
    }
}
