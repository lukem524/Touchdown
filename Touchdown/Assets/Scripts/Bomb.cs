﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Bomb : MonoBehaviour
{
    [SerializeField]
    private float _bombSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //making the ball move into the left position
        transform.Translate(Vector3.left * _bombSpeed * Time.deltaTime);

        //if position of the bomb is less then or equal to 1.4, destory the bomb. 
        if(transform.position.x <= -1.4f){
            Destroy(this.gameObject);
        }
    }

    // If bomb hits the player, destroy the player, reset the Ammo to 0 and go to the main menu scene.
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            Destroy(other.gameObject);
            Ball._ballHolder = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
