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
        
        transform.position = new Vector3(1.5f, 0.406f, 1.3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _enemySpeed *Time.deltaTime);
        if(transform.position.x <-2){
            Destroy(gameObject);
        }
    }

    public void Hurt()
    {
        Destroy(this.gameObject);
    }
}
