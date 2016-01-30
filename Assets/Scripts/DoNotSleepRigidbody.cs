using UnityEngine;
using System.Collections;

public class DoNotSleepRigidbody : MonoBehaviour {
    void Update()
    {
        Rigidbody r = this.GetComponent<Rigidbody>();
        if (r.IsSleeping()) {
            r.WakeUp();
        }
    }
}
