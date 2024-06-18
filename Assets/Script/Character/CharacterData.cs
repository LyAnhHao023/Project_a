using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterStats
{
    public int maxHealth;
    public int strenght;
    public float speed;
    public float crit;
    public float critDmg;
}

[Serializable]
public class SkillInfo
{
    public Sprite Icon;
    public string name;
    public string decription;
    public int strenght;
}

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    public string name;
    public Sprite image;
    public CharacterStats stats;
    public GameObject animatorPrefab;
    public WeaponData beginerWeapon;
    public bool acquired = false;
    public string Story;
    public SkillInfo skillInfo;
}
