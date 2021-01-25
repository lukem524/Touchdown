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
         transform.Translate(Vector3.right * _ballshotSpeed * Time.deltaTime);

         if(transform.position.x > 1.5){
             Destroy(this.gameObject);
         }
    }
}
