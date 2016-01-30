using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoToBedTrigger : MonoBehaviour {
    public GameController gc;

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && SceneManager.GetActiveScene().name == "ApartmentEnd") {
            StartCoroutine(gc.ExitToNextScene());
            this.enabled = false;
        }
    }
}