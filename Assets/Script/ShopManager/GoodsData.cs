using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class levelInfo
{
    public int level;
    public int price;
}

[CreateAssetMenu]
public class GoodsData : ScriptableObject
{
    public Sprite icon;
    public string name;
    public string description;
    public int level;
    public int price;
    public int maxLevel;
    public float percentBuff;
    public bool acquiced = false;
    public List<levelInfo> levelInfos;
}
