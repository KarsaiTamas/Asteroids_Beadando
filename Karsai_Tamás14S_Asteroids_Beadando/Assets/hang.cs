using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hang : MonoBehaviour
{
    bool play;
    private AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.playOnAwake = true;
        audiosource.loop = true;
        play = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            if (play)
            {
                audiosource.mute = play;
                play = false;
            }
            else
            {
                audiosource.mute = play;
                play = true;
            }

        }
    }
}
