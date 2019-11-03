﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizantalMover : MonoBehaviour
{
    float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;


    }

    public IEnumerator Move()
    {
        while (true)
        {
            speed *= -1;
            yield return new WaitForSeconds(2f);
            Flip();
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
