using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallShot : MonoBehaviour
{

    [SerializeField]
    private float _ballshotSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(-1f, 1f, 1.3f);
    }

    // Update is called once per frame
    void Update()
    {
        //making the ball move to the right.
         transform.Translate(Vector3.right * _ballshotSpeed * Time.deltaTime);
        //if the ball's x position is greater than 1.5, destroy the ball shot
         if(transform.position.x > 1.5){
             Destroy(this.gameObject);
         }
    }

    private void OnTriggerEnter(Collider other) {
    if(other.tag == "Bomb"){
        //if this object hits the object with the tag bomb destroy both objects.
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    } 
    }
}
