using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Shoot : MonoBehaviour
{
    public GameObject Bullet;

    public float Speed = 2000;

    // 300 ms
    public float ShootRate = 0.3f;

    public AudioSource ShootSound;

    private float timer = 0f;


    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (timer >= ShootRate)
            {
                var rotation = transform.rotation;
                rotation.y = 0;
                GameObject g = (GameObject) Instantiate(Bullet, transform.position, rotation);
                g.GetComponent<Rigidbody>().AddForce(transform.forward * Speed);
                timer = 0f;
                //ShootSound.mute = false;
            }
            else
            {
                //ShootSound.mute = true;
            }
        }
    }
}

