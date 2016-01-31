using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class TitleScript : MonoBehaviour {
    public GameObject StartUI;
    public GameObject CreditsUI;
    

    public void onPressPlay() { SceneManager.LoadScene("ApartmentStart"); }
    public void onPressCredits()
    {
        StartUI.SetActive(false);
        CreditsUI.SetActive(true);


    }
    public void onPressBack()
    {
        StartUI.SetActive(true);
        CreditsUI.SetActive(false);

    }
}
