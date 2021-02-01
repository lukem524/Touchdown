using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    void Start() {
        
    }

    //Playing the audio globally (throughout the game scenes)
    private static MusicManager instance = null;
    public static MusicManager Instance
    {
            get {return instance;}
    }

    void Awake() 
    {
        if (instance != null && instance != this)
        {
            Destroy (gameObject);
            return;
        }
        else 
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
