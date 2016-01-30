using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Trigger : WeaponPiece
{
    public override void Fire()
    {
        Debug.Log("Trigger Firing!");
    }
}
