using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject textNotification;
    public TMP_Text hintButtonText;
    string[] hintsText;
    bool pause;
    // Start is called before the first frame update
    void Start()
    {
        hintsText = new string[] { "Enable Hints", "Disable Hints"};
        ChangeHintText(!textNotification.activeSelf);
    }


    public void ChangeHintsStatus()
    {
        bool state = textNotification.activeSelf;
        textNotification.SetActive(!state);
        ChangeHintText(state);
    }

    void ChangeHintText(bool state)
    {
        if (state) hintButtonText.text = hintsText[0];
        else hintButtonText.text = hintsText[1];
    }

    public void BackTitle()
    {
        SceneManager.LoadScene("Menu");
    }
}
