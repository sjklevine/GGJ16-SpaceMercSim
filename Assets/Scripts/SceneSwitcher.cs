using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSwitcher : MonoBehaviour {
    float fadeInTime = 5.0f;
    float fadeOutTime = 2.0f;

    public Renderer fadeScreen;

    void Start () {
        StartCoroutine(FadeScreen(Color.black, Color.clear, fadeInTime));        	
	}
	
    public IEnumerator ExitToNextScene() {
        yield return FadeScreen(Color.clear, Color.black, fadeOutTime);
        switch (SceneManager.GetActiveScene().name)
        {
            case "ProtoBedroom":
                SceneManager.LoadScene("ProtoMission");
                break;
            case "ProtoMission":
                SceneManager.LoadScene("ProtoBedroom");
                break;
        }
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
