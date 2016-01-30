using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {
    public float fadeInTime = 5.0f;
    public float fadeOutTime = 2.0f;
    public Renderer fadeScreen;
    public Renderer holoRenderer;
    public Animator holoAnim;
    public Animator bathroomDoorAnim;
    public Animator livingRoomDoorAnim;
    public Texture2D[] infoImages;

    public bool quickStart = true;

    void Start ()
    {
        switch (SceneManager.GetActiveScene().name) {
            case "ApartmentStart":
                if (quickStart) {
                    bathroomDoorAnim.SetTrigger("triggerOpen");
                    livingRoomDoorAnim.SetTrigger("triggerOpen");
                    DoorScript.Open();
                } else {
                    StartCoroutine(StartTheGame());
                }
                break;
            case "ApartmentEnd":
                livingRoomDoorAnim.SetTrigger("triggerOpen");
                DoorScript.Open();
                StartCoroutine(ReadyForBed());
                break;
            default:
                if (!quickStart) { 
                    StartCoroutine(FadeScreen(Color.black, Color.clear, fadeInTime));
                }
                break;
        }
    }
	
    private IEnumerator StartTheGame() {
        // Start from fade, then after a short pause, show the holo!
        yield return FadeScreen(Color.black, Color.clear, fadeInTime);
        yield return new WaitForSeconds(1.0f);
        holoRenderer.material.mainTexture = infoImages[0];
        holoAnim.SetTrigger("triggerHolo");

        // Then shortly after, open the bathroom door.
        yield return new WaitForSeconds(4.0f);
        bathroomDoorAnim.SetTrigger("triggerOpen");
    }

    private IEnumerator ReadyForBed() {
        // Start from fade, then after a short pause, show the holo!
        yield return FadeScreen(Color.black, Color.clear, fadeInTime);
        yield return new WaitForSeconds(1.0f);
        holoRenderer.material.mainTexture = infoImages[0];
        holoAnim.SetTrigger("triggerHolo");
    }

    public void TriggerLivingRoomOpen()
    {
        //This time, open door concurrently with the info.
        livingRoomDoorAnim.SetTrigger("triggerOpen");
        holoRenderer.material.mainTexture = infoImages[1];
        holoAnim.SetTrigger("triggerHolo"); // "Assemble weapon" image

        // Since weapon assembly doesn't quite work yet, open the exit here too!
        DoorScript.Open();
    }

    public IEnumerator ExitToNextScene() {
        Debug.Log("EXIT TO NEXT SCENE!?!?");
        yield return FadeScreen(Color.clear, Color.black, fadeOutTime);
        switch (SceneManager.GetActiveScene().name)
        {
            case "ApartmentStart":
                SceneManager.LoadScene("Mission");
                break;
            case "Mission":
                SceneManager.LoadScene("ApartmentEnd");
                break;
            case "ApartmentEnd":
                SceneManager.LoadScene("Title");
                break;
            case "Title":
                SceneManager.LoadScene("ApartmentStart");
                break;
        }
    }

    public void flashBloodyView()
    {
        StartCoroutine(FadeScreen(Color.red, Color.clear, 3.0f));
    }

    private IEnumerator FadeScreen(Color fromColor, Color toColor, float overTime) {
        fadeScreen.enabled = true;
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            float zeroToOne = (Time.time - startTime) / overTime;
            fadeScreen.material.color = Color.Lerp(fromColor, toColor, zeroToOne);
            yield return null;
        }
        fadeScreen.material.color = toColor;
        if (toColor == Color.clear) {
            fadeScreen.enabled = false;
        }
    }
}
