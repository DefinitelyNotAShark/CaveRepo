using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool shouldMove = false;
    private float height = 0;
    private float speed;


    public void Move(float maxHeight, float doorSpeed)
    {
        height = maxHeight;
        speed = doorSpeed;
        shouldMove = true;
    }

    private void Update()
    {
        if (shouldMove && transform.position.y <= height)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
    }
}
