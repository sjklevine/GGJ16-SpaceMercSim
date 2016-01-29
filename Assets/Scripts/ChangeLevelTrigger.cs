using UnityEngine;
using System.Collections;

public class ChangeLevelTrigger : MonoBehaviour {

    public SceneSwitcher ss;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            StartCoroutine(ss.ExitToNextScene());
        }
    }
}