using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Player
{
    class PlayerStatus : MonoBehaviour
    {
        private float distToGround;


        public bool IsGrounded { get; set; }
        public bool IsJumping { get; set; }
        public bool IsFalling { get; set; }
        public bool JetPackEnabled { get; set; }
        public bool CollisionForward { get; set; }

       
        void FixedUpdate()
        {
            IsFalling = GetComponent<Rigidbody>().velocity.y < -0.05;
            IsJumping = GetComponent<Rigidbody>().velocity.y > 0 && !JetPackEnabled;
           
        }

        void OnCollisionStay(Collision collisionInfo)
        {
            if (collisionInfo.contacts.Length > 0)
            {
                ContactPoint contact = collisionInfo.contacts[0];
                CollisionForward = contact.normal.z < 0;
                IsGrounded = contact.normal.y > 0;
            }
        }

        void OnCollisionExit(Collision collisionInfo)
        {
            IsGrounded = false;
        }

    }
       

    
}
