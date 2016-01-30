using UnityEngine;
using System.Collections;

public class ExitBathroomTrigger : MonoBehaviour {
    public GameController gc;

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            gc.TriggerLivingRoomOpen();
        }
    }
}