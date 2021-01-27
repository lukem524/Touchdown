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
    private float _jumpSpeed = 10f;
    [SerializeField]
    private int _lives = 1;
    [SerializeField]
    private GameObject _ball;
    [SerializeField]
    private Transform _shotPoint;

    public RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        //This is to position the player at the left side of the screen in the ground
        transform.position = new Vector3 (-10f, -2.5f, 1.3f);

    }

    // Update is called once per frame
    void Update()
    {
        //Callling movement method for the player to move.
        Movement();
        float hitDistance = hit.distance;
        Debug.Log(hitDistance);
        if(Physics.Raycast(transform.position,Vector3.down, out hit))
        {
            if(hitDistance > 1.99f){
                Jump();
            }
            
            if(hitDistance > 1){
                if(Input.GetKeyDown("w")){
                shoot();
            }
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
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-10f, 10f),transform.position.y, 1.3f);
    
    

    }
//creating second method for jump function
    void Jump(){
        if (Input.GetButtonDown("Jump")){
            gameObject.GetComponent<Rigidbody>().AddForce(transform.up * _jumpSpeed);
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
