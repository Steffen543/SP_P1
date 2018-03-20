using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Player;
using UnityEngine;

public class MovingPlayerScript : MonoBehaviour
{

    public float Speed = 3f;
    public GameManager Manager;
    public new Rigidbody rigidbody;
    private PlayerMovement movementType = PlayerMovement.FreeMove;

    private float jumpTimer = 0f;



    public float moveSpeed = 10f;
    public float turnSpeed = 300f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        var playerStatus = GetComponent<PlayerStatus>();
        jumpTimer += Time.deltaTime;
        var input = new PlayerInput();
        var runPower = 1f;
        if (input.Run) runPower = 1.5f;

        if (input.SwitchFlyMode)
        {
            if(movementType == PlayerMovement.FreeMove) movementType = PlayerMovement.Forward;
            else if(movementType == PlayerMovement.Forward) movementType = PlayerMovement.FreeMove;
        }

        if (!playerStatus.IsGrounded)
        { // most code has something like this already
            Vector3 vel = rigidbody.velocity;
            vel.y -= 10f * Time.deltaTime;
            rigidbody.velocity = vel;
   
        }


        if (input.Jump && !input.Backward)
        {
            //Debug.Log("jump: " + playerStatus.CanJump +  "(" + rigidbody.velocity.y + ")");
            if (playerStatus.JetPackEnabled)
            {
                var jumpForce = 0.5f;
                rigidbody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.VelocityChange);
            }
            
            else if (playerStatus.IsGrounded && jumpTimer >= 1f)
            {
               
                //var jumpForce = 10.5f;
                var jumpForce = 10.5f;
                var newVector = transform.forward;

                if (input.Run && input.Forward)
                    newVector = newVector / 1;
                else if (input.Forward)
                    newVector = newVector / 2;
                else newVector = newVector / 6;
                newVector.z = 0;
                newVector.x = 0;
                newVector.y = 1.1f;
                rigidbody.AddForce(jumpForce * newVector, ForceMode.VelocityChange);
                jumpTimer = 0f;
            }
          
        }
      

        int backwards = 1;
        //if (playerStatus.IsGrounded || playerStatus.JetPackEnabled || playerStatus.IsJumping || playerStatus.IsFalling){
        if (input.Forward)
            transform.Translate(Vector3.forward * moveSpeed * runPower * Time.deltaTime);
        if (input.Backward)
        {
            backwards = -1;
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }
        //}
        if (playerStatus.IsGrounded || playerStatus.JetPackEnabled || playerStatus.IsJumping)
        {
           

        }

        if (input.Left)
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime * backwards);
        if (input.Right)
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * backwards);
                

        
    }





}

public enum PlayerMovement
{
    FreeMove,
    Forward
}
