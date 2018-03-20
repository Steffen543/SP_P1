using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour
{

    public GameManager GameManager;
    private bool moving;
    private float collisionLeaveTimer = 0f;
  

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        var isOutOfField = transform.position.y < -20;
        if (isOutOfField)
        {
           
            transform.position = GameManager.Checkpoint.transform.position;
            //transform.rotation = GameManager.Checkpoint.transform.rotation;
            Debug.Log(GameManager.Checkpoint.transform.rotation);
            transform.rotation = Quaternion.Euler(GameManager.Checkpoint.transform.rotation.x, GameManager.Checkpoint.transform.rotation.y, GameManager.Checkpoint.transform.rotation.z);
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
            
    }

   


    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.gameObject.tag == "MovingGroundX")
        {
            transform.parent = collisionInfo.collider.transform.parent;
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "MovingGroundX")
        {
            transform.parent = null;
        }
       
    }

    void OnTriggerExit(Collider other)
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            GameManager.AddPoints(1);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Enemy")
        {
            transform.position = new Vector3(-50, 12.5f, -40);
            Debug.Log("Collided with enemy");
        }
        if (other.gameObject.tag == "Checkpoint")
        {
            GameManager.Checkpoint = other.gameObject;
            //Debug.Log("Collided with checkpoint");
        }
        if (other.gameObject.tag == "Water")
        {
            transform.position = GameManager.Checkpoint.transform.position;
            transform.rotation = GameManager.Checkpoint.transform.rotation;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Debug.Log("Collided with Water");
        }
       

    }


}
