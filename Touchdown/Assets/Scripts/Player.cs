using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpawnManager _spawnManager;

    private Ball Ball;
    
    //Creating a private float variable for speed.
    [SerializeField]
    private float _playerSpeed = 1f;

    [SerializeField]
    private float _jumpSpeed = 1f;
    [SerializeField]
    private int _lives = 1;
    [SerializeField]
    private GameObject _ball;
    [SerializeField]
    private Transform _shotPoint;

    [SerializeField]
    private float _ballSpeed = 2f;

    public RaycastHit hit;
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
        
        if(Physics.Raycast(transform.position,Vector3.down, out hit))
        {
            float hitDistance = hit.distance;
            if(hitDistance < 0.07f)
            {
                Jump();
            }

            if(hitDistance > 0.07){
                if(Input.GetKeyDown("w")){
                shoot();
            }
            Debug.Log(hitDistance);
        }
        
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
//creating second method for jump function
    void Jump(){
        float hitDistance = hit.distance;
        if (Input.GetButtonDown("Jump")){
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, _jumpSpeed, 0f), ForceMode.Impulse);
            }
        }

    }
    public void shoot(){
        if(Ball._ballHolder >= 1){
            Instantiate(_ball, _shotPoint.position, Quaternion.identity);
            Ball._ballHolder -= 1;
        }
        else{
            return;
        }
            
        }


    public void Damage()
    {
        _lives -= 1;
        Debug.Log(_lives);
        //if there are no lives, kill the player
        if(_lives <= 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }
    }
