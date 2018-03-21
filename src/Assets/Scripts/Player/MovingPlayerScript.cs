using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Player;
using UnityEngine;

public class MovingPlayerScript : MonoBehaviour
{
	private PlayerStatus playerStatus;
	private Rigidbody rigidbody;
	private float jumpTimer = 0f;
	
    public float moveSpeed = 10f;
    public float turnSpeed = 300f;
	public GameManager Manager;
	public float Speed = 3f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
		playerStatus = GetComponent<PlayerStatus>();
    }

    private void FixedUpdate()
    {
        jumpTimer += Time.deltaTime;
        var input = new PlayerInput();
        var runPower = 1f;
        if (input.Run) runPower = 1.5f;

      
		/* if the player is in the air,
		 * he must fall faster, so the y-velocity
		 * is reduced */
        if (!playerStatus.IsGrounded)
        { 
            Vector3 vel = rigidbody.velocity;
            vel.y -= 10f * Time.deltaTime;
            rigidbody.velocity = vel;
        }

		/* the player can't jump if he is
		 * walking backwards, so check it */
        if (input.Jump && !input.Backward)
        {
			/* if the jetpack is enabled, there is 
			 * an other jump-behaviour for the jetpack.
			 * So a velocity change in y-direction is done. */
            if (playerStatus.JetPackEnabled)
            {
                var jumpForce = 0.5f;
                rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.VelocityChange);
            }
            /* if the jetpack is not enabled, it must be secured
			 * that the player is on the ground and that the lastJump
			 * was more than a second ago */
            else if (playerStatus.IsGrounded && jumpTimer >= 1f)
            {
                var jumpForce = 10.5f;
				// take the forward vector for a jump
                var newVector = transform.forward;

				/* if the player is running and goind forward,
 				 * a big jump must be executed, so we take the normal
				 * forward vector */
                if (input.Run && input.Forward)
                    newVector = newVector / 1;
				/* if the player is goind forward,
 				 * a normal jump must be executed, so we take the normal
				 * forward vector and half it ^*/
                else if (input.Forward)
                    newVector = newVector / 2;
				/* if the player executes a jump without moving forward,
				 * a small jump has to be done, so we divide the 
				 * forward vector with 6 */
                else
					newVector = newVector / 6;
				
				//TODO: check if this is right
                newVector.z = 0;
                newVector.x = 0;
                newVector.y = 1.1f;
                rigidbody.AddForce(jumpForce * newVector, ForceMode.VelocityChange);
                jumpTimer = 0f;
            }
          
        }
      

        int backwards = 1;
        // if (playerStatus.IsGrounded || playerStatus.JetPackEnabled || playerStatus.IsJumping || playerStatus.IsFalling){
		// if (playerStatus.IsGrounded || playerStatus.JetPackEnabled || playerStatus.IsJumping) { }
        if (input.Forward)
            transform.Translate(Vector3.forward * moveSpeed * runPower * Time.deltaTime);
        if (input.Backward)
        {
            backwards = -1;
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }
        

        if (input.Left)
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime * backwards);
        if (input.Right)
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * backwards);

    }
}
