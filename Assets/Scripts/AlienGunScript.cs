using UnityEngine;
using System;
using System.Collections;

public class AlienGunScript : MonoBehaviour {
    public int whichHand = 0; // 0 = left, 1 = right
    public ParticleSystem particles;
    public Transform emitPoint;
    public float raycastDistance = 10.0f;

    void Update () {
        if (SixenseInput.Controllers[whichHand].Enabled) {
            if (SixenseInput.Controllers[whichHand].GetButtonDown(SixenseButtons.TRIGGER)) {
                fireLaser();
            }
        }
    }

    private void fireLaser() {
        Debug.Log("PEW PEW");
        GameObject.Instantiate(particles, emitPoint.position, emitPoint.rotation);

        //Do a RAYCAST!  if you hit the Victim, tell him to explode.
        RaycastHit hit;
        Vector3 fwd = emitPoint.TransformDirection(Vector3.forward);
        if (Physics.Raycast(emitPoint.position, fwd, out hit, raycastDistance)) {
            print("RAYCAST HIT!  hit = " + hit.collider.name);
            if (hit.collider.tag == "Victim")
            {
                VictimScript v = hit.collider.GetComponent<VictimScript>();
                v.explode();
            }
        }
    }
}