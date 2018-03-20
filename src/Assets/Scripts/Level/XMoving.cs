using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XMoving : MonoBehaviour {

    private bool isMoving;
    private Vector3 originalPosition;
    //private new Rigidbody rigidbody;
    public float Toleration = 10f;
    private Direction direction;
    public float Speed = 1f;

    void Start()
    {
        originalPosition = transform.position;
        //rigidbody = GetComponent<Rigidbody>();
        direction = Direction.Right;
    }

    private void FixedUpdate()
    {
        float width = transform.lossyScale.x;
        float originalX = originalPosition.x;
        float x = transform.position.x;


        if (x < (originalX - width / 2) - Toleration)
            direction = Direction.Right;
        else if (x > originalX + (width / 2) + Toleration)
            direction = Direction.Left;

        if (direction == Direction.Right)
            x += 0.01f * Speed;
        else x -= 0.01f * Speed;

        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
