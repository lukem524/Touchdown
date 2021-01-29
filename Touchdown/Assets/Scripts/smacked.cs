using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smacked : MonoBehaviour
{
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

            Destroy(transform.parent.gameObject, 0f);
            Score.scoreValue += 1;
        }
    }
}
