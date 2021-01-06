using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling : MonoBehaviour
{

    [SerializeField]
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.x += Time.deltaTime/speed;
        mat.mainTextureOffset = offset;
    }
}
