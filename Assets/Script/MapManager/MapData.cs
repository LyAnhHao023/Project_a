using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class MapData : ScriptableObject
{
    public SceneAsset Map;
    public string Name;
    public Sprite Icon;
    public bool storyCleared = false;
}
