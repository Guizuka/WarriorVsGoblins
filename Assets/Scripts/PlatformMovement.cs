using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    public float dirX, moveSpeed = 100f;
    public bool moveRight = true;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > -600f)
        {
            moveRight = false;
        }
        if (transform.position.x < -1200f)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }
}
