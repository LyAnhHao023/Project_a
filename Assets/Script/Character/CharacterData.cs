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


[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    public string name;
    public Sprite image;
    public CharacterStats stats;
    public GameObject animatorPrefab;
    public WeaponData beginerWeapon;

}
