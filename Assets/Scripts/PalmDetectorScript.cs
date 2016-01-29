using UnityEngine;
using System.Collections;

public class PalmDetectorScript : MonoBehaviour {
    void OnCollisionEnter(Collision collision)
    {
        //TODO: SAM HERE; add audio or force or trigger aniamations or do anything cool@
        Debug.Log("Palm " + this.name + " collided with " + gameObject.name + "!");
        /*
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        if (collision.relativeVelocity.magnitude > 2)
            audio.Play();
       */
    }
}