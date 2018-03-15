using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour {

    public float Speed = 1f;
    public GameManager Manager;
    private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        float run = 1f;
   
        if (Input.GetKey(KeyCode.LeftShift)) run = 5.5f;

        Debug.Log("run: " + run);

        if (Input.GetAxis("Jump") != 0 && rigidbody.velocity.y == 0)
        {
            var jumpForce = 6f;
            rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        rigidbody.AddForce(movement * Speed * run);

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            Manager.AddPoints(1);
            other.gameObject.SetActive(false);
        }
    }
}
