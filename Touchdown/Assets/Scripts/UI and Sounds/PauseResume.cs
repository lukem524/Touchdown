using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject PauseButton;

    bool GamePaused;
    // Start is called before the first frame update
    void Start()
    {
        GamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GamePaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void PauseGame() //When pressing pause button
    {
        GamePaused = true; //Game stops
        PauseScreen.SetActive(true); //Pause screen shows
        PauseButton.SetActive(false); //Pause button hides
    }

    public void ResumeGame()
    {
        GamePaused = false; //Game resumes
        PauseScreen.SetActive(false); //Pause screen hides 
        PauseButton.SetActive(true); //Pause button reappears
    }
}
