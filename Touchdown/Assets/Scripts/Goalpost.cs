using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalpost : MonoBehaviour
{


    [SerializeField]
    public float speed = 1.5f;
    [SerializeField]
    bool _switch = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //switching the position of the goal post movement, depending on the statis of the switch

            //if switch is set to true, move the post up
            if(_switch){
                movePostUp();
            //if switch is set to false, move the post down. 
    } else if(!_switch){
        movePostDown();
    }
    // if positions is greater or equal than 1.3f, set the switch to false.
    if(transform.position.y >= 1.3f){
        _switch = false;
    } 
    //if position is less then or equal than 0.45f, set the switch to true.
    if(transform.position.y <= 0.45f){
        _switch = true;
    }
    }

    //created functions for up and down movement to be called in the update function.
    private void movePostUp(){
        transform.Translate(0,speed*Time.deltaTime, 0);
    }
    private void movePostDown(){
                transform.Translate(0,-speed*Time.deltaTime, 0);
    }

    //if the goalpost get's in touch with the shot ball, destroy the shot ball and add 1 to the score. 
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "ball_shot"){
            Destroy(other.gameObject);
            Score.scoreValue += 1;
        }
    }
}
