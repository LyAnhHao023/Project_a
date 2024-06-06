using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

[CreateAssetMenu]
public class UpdateInfo : ScriptableObject
{
    public int level;
    public string description;
    public WeaponStats stats;
}
