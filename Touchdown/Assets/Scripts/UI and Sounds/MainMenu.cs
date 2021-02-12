using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //Calling the use for SceneManagement to have the ability to switch scenes

public class MainMenu : MonoBehaviour
{
    public Text HSText;

    private void Start() 
    {
        HSText.text = "HIGHSCORE:" + "" + PlayerPrefs.GetInt("highscore");
    }
    public void PlayGame ()
    {
        //Used SceneManger to load the current scene 'MainMenu' and added te value +1 to go to the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        Application.Quit();
        Debug.Log("Exiting Game");//Added Debug to make sure button is working since it is not possible to quit the application in inspector 
    }
}