using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public ItemsData itemsData;

    public virtual void Update()
    {
    }
    public abstract void ItemEffect();
}
