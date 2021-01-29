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

        //getting the components for the mesh renderer and material of the quad object.
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;
        Vector3 offset = mat.mainTextureOffset;
        //mobing the material in order to give an endless runner effect.
        offset.x += Time.deltaTime/speed;
        mat.mainTextureOffset = offset;
    }
}
