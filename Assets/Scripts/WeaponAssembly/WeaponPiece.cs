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
        Resonator,
        CraftedTrigger,
        CraftedBody,
    }

    [SerializeField]
    private WeaponPieceType _type;
    public WeaponPieceType Type { get { return _type; } }

    [SerializeField]
    private Transform _snappingPoint;
    public Transform SnappingPoint { get { return _snappingPoint; } }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<WeaponPiece>() != null)
        {
            MessageSystem.Default.Broadcast(new TrySnapItemsMessage());
        }
    }
}
