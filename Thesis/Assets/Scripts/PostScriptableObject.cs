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

    public bool itIsFakeNews;

    public string communityNote01;
    public bool isFlagged01;
    
    public string communityNote02;
    public bool isFlagged02;
    
    public string communityNote03;
    public bool isFlagged03;

}
