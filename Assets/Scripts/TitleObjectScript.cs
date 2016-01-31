using UnityEngine;
using System.Collections;

public class TitleObjectScript : MonoBehaviour
{
    public enum WhichButton { Play, Credits, Back };
    public WhichButton whichButton;
    public GameController gc;
    public TitleScript ts;

    private bool activated;
    private int whichHand = -1;
    
	void Update () {
        if (activated)
        {
            this.transform.Rotate(new Vector3(0,5.0f,0));

            if (SixenseInput.Controllers[whichHand].GetButtonDown(SixenseButtons.TRIGGER))
            {
                switch (whichButton)
                {
                    case WhichButton.Play:
                        StartCoroutine(gc.ExitToNextScene());
                        break;
                    case WhichButton.Credits:
                        ts.onPressCredits();
                        break;
                    case WhichButton.Back:
                        ts.onPressBack();
                        break;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LeftHand")
        {
            whichHand = 1;
        }
        else if (other.gameObject.tag == "RightHand")
        {
            whichHand = 0;
        }
        activated = true;
    }

    void OnTriggerExit(Collider other)
    {
        whichHand = -1;
        activated = false;
    }
}