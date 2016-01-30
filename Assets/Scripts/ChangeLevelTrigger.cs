using UnityEngine;
using System.Collections;

public class ChangeLevelTrigger : MonoBehaviour {

    public GameController gc;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            StartCoroutine(gc.ExitToNextScene());
            this.enabled = false;
        }
    }
}