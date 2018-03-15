using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        //this.transform.position = target.transform.position;

        Vector3 cameraPosition = new Vector3(target.transform.position.x, target.transform.position.y + 20, target.transform.position.z - 15);
        transform.position = cameraPosition;
    }

    
}
