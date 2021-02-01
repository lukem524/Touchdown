using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class smacked : MonoBehaviour
{
    [SerializeField]
    public AudioSource DeathSound; //Created an audio source called DeathSound to be able to place the audio file needed in unity
    public AudioSource ScoreSound; //Created an audio source called ScoreSound to be able to place the audio file needed in unity

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {

        //if the top collider get's in contact with the player, destory the enemy and add 1 to score.
        if (other.name == "Player")
        {
            foreach(Transform child in transform)
            child.gameObject.SetActive(false);
            DeathSound.Play();//Audio Source DeathSound will play after enemy dies

            Destroy(transform.parent.gameObject, 0f);
            ScoreSound.Play();//Audio Source ScoreSound will play after player dies
            Score.scoreValue += 1;

        }
    }
}
