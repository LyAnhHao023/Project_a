using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public ItemsData itemsData;
    public int level;

    public void SetLevelBase(ItemBase itemBase)
    {
        level = itemBase.level;
    }

    public virtual void Update()
    {
    }
    public abstract void ItemEffect();
}
