using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject target;
    private Vector3 offset;

    private int mode = 0;


    // Use this for initialization
    void Start () {
        offset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update () {

        switch (mode)
        {
            case 0:
                transform.position = target.transform.position + offset;
                break;
            case 1:
                var newPosition = target.transform.position - target.transform.forward * 13f;
                transform.position = newPosition;
                transform.LookAt(target.transform.position);
                transform.position = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
                break;
        }

      

    }


}
