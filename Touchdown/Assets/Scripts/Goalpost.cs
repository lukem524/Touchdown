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
        
            if(_switch){
                movePostUp();
    } else if(!_switch){
        movePostDown();
    }

    if(transform.position.y >= 1.8f){
        _switch = false;
    } if(transform.position.y <= -1.8f){
        _switch = true;
    }
    }

    private void movePostUp(){
        transform.Translate(0,speed*Time.deltaTime, 0);
    }
    private void movePostDown(){
                transform.Translate(0,-speed*Time.deltaTime, 0);
    }


    private void OnTriggerEnter(Collider other) {
        if(other.tag == "ball_shot"){
            Destroy(other.gameObject);
            Score.scoreValue += 1;
        }
    }
}
