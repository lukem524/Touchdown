using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    [SerializeField]
    public AudioSource DeathMusic;//Created an audio source called JumpSound to be able to place the audio file needed in unity

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    
    void OnTriggerEnter(Collider other) {
        //if the bottom collider of the enemy touches the player, the player dies, score is set to 0, ammo is set to 0 and the main menu scene is loaded.
        if(other.tag == "Player"){
            Player player = other.GetComponent<Player>();
            if (Score.scoreValue > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", Score.scoreValue);
            }
            
            if(player != null)
            {
                Destroy(other.gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                DeathMusic.Play();//Audio Source DeathSound will play after enemy dies
                Score.scoreValue = 0;
                Ball._ballHolder = 0;
            }
            
        }
    }
}
