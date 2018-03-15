using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public GameObject target;
    private Rigidbody rigidbody;
    public float Speed = 3f;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float x = target.transform.position.x - rigidbody.position.x;
        float z = target.transform.position.z - rigidbody.position.z;

        Vector3 newPos = new Vector3(x, 0, z);
        newPos.Normalize();

        rigidbody.AddForce(newPos * Speed);
    }
}
