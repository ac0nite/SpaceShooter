using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammunition : MonoBehaviour
{
    protected TypeAmmunition Type = TypeAmmunition.Undefined;
    protected int Count = 0;

    public virtual void Adding(int count)
    {
        Count += count;
    }
    
    /// <summary>
    /// Проверяется наличие боеприпасов, если есть то отнимается единица
    /// </summary>
    /// <returns>true-есть, false-нету</returns>
    public virtual bool isAmmunition()
    {
        Debug.Log($"Count: {Count}");
        if (Count == 0) return false;
        Count--;
        return true;
    }
}
