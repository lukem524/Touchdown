using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalpost : MonoBehaviour
{


    [SerializeField]
    public float speed = 1f;
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
                moveBirdUp();
    } else if(!_switch){
        moveBirdDown();
    }

    if(transform.position.y >= 1.3f){
        _switch = false;
    } if(transform.position.y <= 0.45f){
        _switch = true;
    }
    }

    private void moveBirdUp(){
        transform.Translate(0,speed*Time.deltaTime, 0);
    }
    private void moveBirdDown(){
                transform.Translate(0,-speed*Time.deltaTime, 0);
    }
}
