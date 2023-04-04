using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTeleport : MonoBehaviour
{
    public GameObject Ui; //test if teleport is working anot

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sceneTeleportStartingRoom() {
        SceneManager.LoadScene("StartingRoom");
        Ui.SetActive(true);
    }

    public void sceneTeleportHUD() {
        SceneManager.LoadScene("4_HUD");
        Ui.SetActive(true);
    }

    public void sceneTeleportResize() {
        SceneManager.LoadScene("1_Resize");
        Ui.SetActive(true);
    }

    public void sceneTeleportHicksLaw() {
        SceneManager.LoadScene("2_HicksLaw");
        Ui.SetActive(true);
    }

    public void sceneTeleportFreeSet() {
        SceneManager.LoadScene("Free Set");
        Ui.SetActive(true);
    }

    public void sceneTeleportGarage() {
        SceneManager.LoadScene("3_Grabbing");
        Ui.SetActive(true);
    }

    public void sceneTeleportRelocation() {
        SceneManager.LoadScene("RelocationDistance");
        Ui.SetActive(true);
    }
    
    public void sceneTeleportOculus() {
        SceneManager.LoadScene("Oculus");
        Ui.SetActive(true);
    }
}
