using UnityEngine;
using System.Collections;

public class TestWeaponAssembly : MonoBehaviour
{
    public WeaponPiece _testNozzle;
    public WeaponPiece _testResonator;
    public WeaponPiece _testTrigger1;
    public WeaponPiece _testTrigger2;

    private Weapon _testWeapon = new Weapon();

    //// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _testWeapon.AddWeaponPiece(_testNozzle);
            Destroy(_testNozzle.gameObject);
            _testNozzle = null;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _testWeapon.AddWeaponPiece(_testResonator);
            Destroy(_testResonator.gameObject);
            _testResonator = null;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _testWeapon.AddWeaponPiece(_testTrigger1);
            Destroy(_testTrigger1.gameObject);
            _testTrigger1 = null;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _testWeapon.AddWeaponPiece(_testTrigger2);
            Destroy(_testTrigger2.gameObject);
            _testTrigger2 = null;
        }
    }
}
