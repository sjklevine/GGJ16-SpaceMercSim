using UnityEngine;
using System.Collections;

public class AlienGunScript : MonoBehaviour {
    public int whichHand = 0; // 0 = left, 1 = right
    public ParticleSystem particles;
    public Transform emitPoint;

    void Update () {

        if (SixenseInput.Controllers[whichHand].Enabled) {
            if (SixenseInput.Controllers[whichHand].GetButtonDown(SixenseButtons.JOYSTICK)) {
                fireLaser();
            }
        }
    }

    private void fireLaser() {
        Debug.Log("PEW PEW");
        GameObject.Instantiate(particles, emitPoint.position, emitPoint.rotation);
    }
}