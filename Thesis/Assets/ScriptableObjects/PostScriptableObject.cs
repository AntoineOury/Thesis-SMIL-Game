using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

[CreateAssetMenu(menuName = "ScriptableObjects/Posts", fileName= "PostSO")]
public class PostScriptableObject : ScriptableObject
{
    public Image postImage;
    public Image accountImage;

    public TMP_Text communityNote; 
}
