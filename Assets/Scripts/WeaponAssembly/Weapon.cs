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

    private List<WeaponPiece> _weaponPieces = new List<WeaponPiece>();
    private EssentialPieces _canFire = EssentialPieces.None;

    public void AddWeaponPiece(WeaponPiece piece)
    {
        if (_weaponPieces.Contains(piece))
            return;

        if (piece is Resonator)
            _canFire |= EssentialPieces.Resonator;
        else if (piece is Nozzle)
            _canFire |= EssentialPieces.Nozzle;
        else if (piece is Trigger)
            _canFire |= EssentialPieces.Trigger;

        _weaponPieces.Add(piece);

        Debug.Log("Picked up a " + piece.GetType().Name);
    }

    public void Fire()
    {
        if ((_canFire & (EssentialPieces.Nozzle | EssentialPieces.Resonator | EssentialPieces.Trigger)) > EssentialPieces.None)
        {
            foreach (var piece in _weaponPieces)
                piece.Fire();
        }
        else
        {
            Debug.Log("Can't Fire!");
        }
    }
}
