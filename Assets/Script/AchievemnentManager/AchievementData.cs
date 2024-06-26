using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ArchievementData : ScriptableObject
{
    public Sprite icon;
    public string achieName;
    public string description;
    public int points;
    public bool complete = false;
}