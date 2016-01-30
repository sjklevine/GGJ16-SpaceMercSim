using UnityEngine;
using System.Collections;

public class Resonator : WeaponPiece
{
    [SerializeField]
    private float _damage = 5f;
    public float Damage { get { return _damage; } }
}
