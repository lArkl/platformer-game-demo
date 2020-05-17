using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PressPlay()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void PressQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void PressAbout()
    {

    }
}
