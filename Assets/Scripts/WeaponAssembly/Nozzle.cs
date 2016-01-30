using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Nozzle : WeaponPiece
{
    [SerializeField]
    private ParticleSystem _particleSystem;

    public override void Fire()
    {
        Debug.Log("Nozzle Firing!");
        if (_particleSystem != null)
        {
            _particleSystem.loop = false;
            _particleSystem.Play();
        }
    }
}
