using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XMoving : MonoBehaviour {

	private Vector3 originalPosition;
    
	/* x direction */
	public bool XMovingEnabled = false;
	public float XToleration = 10f;
	public float XSpeed = 1f;
	
	/* y direction */
	public bool YMovingEnabled = false;
	public float YToleration = 10f;
	public float YSpeed = 1f;
	
	/* z direction */
	public bool ZMovingEnabled = false;
	public float ZToleration = 10f;
	public float ZSpeed = 1f;
	
	
    void Start()
    {
        originalPosition = transform.position;
    }

    private void FixedUpdate()
    {
       var newTransform = transform.position;
	   
	   if(XMovingEnabled)
		   newTransform.x = UpdateX();
	   if(YMovingEnabled)
		   newTransform.y = UpdateY();
	   if(ZMovingEnabled)
		   newTransform.z = UpdateZ();
	   
	   transform.position = newTransform;
    }
	
	private void UpdateX() {
		float width = transform.lossyScale.x;
        float originalX = originalPosition.x;
        float x = transform.position.x;
        if (x < (originalX - width / 2) - Toleration)
            x += 0.01f * XSpeed;
        else if (x > originalX + (width / 2) + Toleration)
            x -= 0.01f * XSpeed;
		return x;
	}
	
	private void UpdateY() {
		float width = transform.lossyScale.y;
        float originalX = originalPosition.y;
        float y = transform.position.y;
        if (y < (originalX - width / 2) - Toleration)
            y += 0.01f * SpeedY;
        else if (y > originalX + (width / 2) + Toleration)
            y -= 0.01f * SpeedY;
		return y;
	}
	
	private void UpdateZ() {
		float width = transform.lossyScale.z;
        float originalX = originalPosition.z;
        float z = transform.position.z;
        if (z < (originalX - width / 2) - Toleration)
            z += 0.01f * SpeedZ;
        else if (z > originalX + (width / 2) + Toleration)
            z -= 0.01f * SpeedZ;
		return z;
	}
}
