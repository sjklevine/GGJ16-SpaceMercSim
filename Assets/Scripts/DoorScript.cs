using UnityEngine;
using System.Collections;

public static class DoorScript {

    public static void Open() {
        GameObject thedoor = GameObject.FindWithTag("SF_Door");
        thedoor.GetComponent<Animation>().Play("open");
    }

    public static void Close()
    {
        GameObject thedoor = GameObject.FindWithTag("SF_Door");
        thedoor.GetComponent<Animation>().Play("close");
    }
}