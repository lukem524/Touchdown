using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField]
    private float _speed;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ballLaunch();
        if(transform.position.x < -1.5f){
            Destroy(this.gameObject);
        }
    }

    private void ballLaunch(){
        transform.Translate(new Vector3(-1f,0f,0f) * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            Destroy(this.gameObject);
            Score.scoreValue += 1;
        }
    }
}
