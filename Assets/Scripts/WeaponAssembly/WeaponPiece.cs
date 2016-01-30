using UnityEngine;
using System.Collections;
using System;
using Messaging;

public class WeaponPiece : MonoBehaviour
{
    public enum WeaponPieceType
    {
        Trigger,
        Nozzle,
        Resonator
    }

    [SerializeField]
    private WeaponPieceType _type;
    public WeaponPieceType Type { get { return _type; } }
}
