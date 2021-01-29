using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
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
            if(player != null)
            {
                Destroy(other.gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                Score.scoreValue = 0;
                Ball._ballHolder = 0;
            }
            
        }
    }
}
