using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "ScriptableObjects/Posts", fileName= "PostSO")]
public class PostScriptableObject : ScriptableObject
{
    public Sprite postImage;
    public Sprite accountImage;

    // public string[] communityNote;
}
