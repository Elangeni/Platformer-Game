using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    AudioSource fxSound; 
    public AudioClip backMusic;

    // Start is called before the first frame update
    public Transform target;
    void Start()
    {
        fxSound = GetComponent<AudioSource>();
        fxSound.clip = backMusic;
        fxSound.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;

        if (target.position.x < 0)
        {
            return;
        }
        pos.x = target.position.x;
        //pos.y = target.position.y;
        transform.position = pos;
    }
}
