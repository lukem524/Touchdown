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


    

    // Start is called before the first frame update
    void Start()
    {
    _Holder = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    _Holder.text = "Ammo" + _ballHolder;
    }

    private void ballLaunch(){
        transform.Translate(new Vector3(-1f,0f,0f) * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            Destroy(this.gameObject);
            _ballHolder += 1;
            Score.scoreValue += 1;
        }
    }
}
