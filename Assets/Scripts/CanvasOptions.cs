using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasOptions : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject controlsPanel;
    // Start is called before the first frame update

    void Start()
    {
        if (ScoreKeeper.deaths == 0)
            controlsPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool paused = !pausePanel.activeSelf;
            ChangeGameState(paused);
        }
    }

    public void ChangeGameState(bool paused)
    {
        if (paused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        pausePanel.SetActive(paused);
    }
}
