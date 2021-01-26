using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Bomb : MonoBehaviour
{
    [SerializeField]
    private float _bombSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * _bombSpeed * Time.deltaTime);

        if(transform.position.x <= -1.4f){
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            Destroy(other.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
