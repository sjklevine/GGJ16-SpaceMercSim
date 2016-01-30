using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Weapon
{
    [Flags]
    private enum EssentialPieces
    {
        None,
        Trigger,
        Nozzle,
        Resonator
    }

    private EssentialPieces _canFire = EssentialPieces.None;

    public bool IsWeaponComplete { get { return (_canFire & (EssentialPieces.Nozzle | EssentialPieces.Resonator | EssentialPieces.Trigger)) > EssentialPieces.None; } }

    public void AddWeaponPiece(WeaponPiece piece)
    {
        if (piece.Type == WeaponPiece.WeaponPieceType.Resonator)
            _canFire |= EssentialPieces.Resonator;
        else if (piece.Type == WeaponPiece.WeaponPieceType.Nozzle)
            _canFire |= EssentialPieces.Nozzle;
        else if (piece.Type == WeaponPiece.WeaponPieceType.Trigger)
            _canFire |= EssentialPieces.Trigger;
    }
}
