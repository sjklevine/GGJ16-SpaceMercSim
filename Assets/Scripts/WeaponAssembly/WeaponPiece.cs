using UnityEngine;
using System.Collections;
using System;
using Messaging;

public abstract class WeaponPiece : MonoBehaviour
{
    public virtual void Fire()
    {
        Debug.Log(this.GetType().Name + " firing!");
    }
}
