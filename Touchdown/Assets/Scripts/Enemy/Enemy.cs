using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float _enemySpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
        transform.position = new Vector3(1.5f, 0.6f, 1.3f);
    }

    // Update is called once per frame
    void Update()
    {
        //moving the enemy to the left position. 
        transform.Translate(Vector3.left * _enemySpeed *Time.deltaTime);
        //if position of the enemey is less than -2, destroy this game object.
        if(transform.position.x <-2){
            Destroy(gameObject);
        }
    }

    
    public void Hurt()
    {
        Destroy(this.gameObject);
    }

}
