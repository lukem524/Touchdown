using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    [SerializeField]
    private float _speed;
    public static int _ballHolder = 0;

    private Text _Holder;


    [SerializeField]

    public AudioSource BallCollect;

    // Start is called before the first frame update
    void Start()
    {
        //getting the text inside the canvas
    _Holder = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //setting the text to read Ammo: + the amount of balls catched/thrown.
        _Holder.text = "Ammo: " + _ballHolder;
    }

    private void ballLaunch(){
        transform.Translate(new Vector3(-1f,0f,0f) * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        //if the ball hits the other player, the ball get's destroyed. 
        if(other.tag == "Player"){
            Destroy(this.gameObject);
            BallCollect.Play();
            _ballHolder += 1;
            
        }
    }
}
