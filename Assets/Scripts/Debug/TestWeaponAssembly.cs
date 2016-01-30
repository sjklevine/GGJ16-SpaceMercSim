using UnityEngine;
using System.Collections;

public class TestWeaponAssembly : MonoBehaviour
{
    public Nozzle _testNozzle;
    public Resonator _testResonator;
    public Trigger _testTrigger;

    private Weapon _testWeapon = new Weapon();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _testWeapon.AddWeaponPiece(_testNozzle);
            Destroy(_testNozzle);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _testWeapon.AddWeaponPiece(_testResonator);
            Destroy(_testResonator);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _testWeapon.AddWeaponPiece(_testTrigger);
            Destroy(_testTrigger);
        }

        if (Input.GetMouseButtonDown(0))
        {
            _testWeapon.Fire();
        }
    }
}
