using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    //Creating a private float variable for speed.
    [SerializeField]
    private float _playerSpeed = 1f;

    [SerializeField]
    private float _jumpSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //This is to position the player at the left side of the screen in the ground
        transform.position = new Vector3 (-1.1f, 0.45f, 1.3f);

    }

    // Update is called once per frame
    void Update()
    {
        //Callling movement method for the player to move.
        Movement();
        Jump();
    }

    /*Creating a seperate method for movement, so that only the method
    get's called every frame and not every line of code.*/
    void Movement()
    {
        /*Getting the return axis: 1=right, -1=left
        In our case, (Horizontal) the keyboard input "D" 
        key returns 1 and "A" key returns -1 */
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Move the player in the X-axis only for now
        Vector3 direction = new Vector3(horizontal, 0, 0);
        //Making player movement m/s
        transform.Translate(direction*_playerSpeed*Time.deltaTime);


        //Restricting player movement till the edge of the screen using mathf class
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-1.2f, 1.2f),transform.position.y, 1.3f);
    
    

    }

    void Jump(){
        if (Input.GetButtonDown("Jump")){
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, _jumpSpeed, 0f), ForceMode.Impulse);
        }
    }


}
