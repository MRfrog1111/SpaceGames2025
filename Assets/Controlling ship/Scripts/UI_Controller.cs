using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    public GameObject ISS;
    public GameObject mainUI;
    public GameObject startUI;
    public GameObject centerUI;
    public GameObject player;
    public GameObject tutorialUI;
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        ISS.SetActive(true);
        mainUI.SetActive(true);
        startUI.SetActive(false);
        centerUI.SetActive(true);
        player.GetComponent<Moving>().enabled = true;
    }

    public void OpenTutorial()
    {
        startUI.SetActive(!startUI.activeSelf);
        tutorialUI.SetActive(!tutorialUI.activeSelf);
    }
}
