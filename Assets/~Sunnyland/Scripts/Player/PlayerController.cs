/*=============================================
-----------------------------------
Copyright (c) 2018 Yongli Wang
-----------------------------------
@file: PlayerController.cs
@date: 12/03/2018
@author: Yongli Wang
@brief: Script to control the Player
===============================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand.Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]

    public class PlayerController : MonoBehaviour
    {
        public float speed = 0.5f;
        public float maxVelocity = 2f;
        public float rayDistance = .5f;
        public float jumpHeight = 3f;
        public int maxJumpCount = 2;
        public LayerMask groundLayer;

        private Vector3 moveDirection;
        private int currentJump = 0;

        //References
        private SpriteRenderer rend;
        private Animator anim;
        private Rigidbody2D rigid;


        #region Unity Functions
        void Start()
        {
            rend = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
            rigid = GetComponent<Rigidbody2D>();
        }

        
        void Update()
        {
            //apply gravity to move direction
            moveDirection.y += Physics.gravity.y * Time.deltaTime; 
        }

        //void FixedUpdate()
        //{
        //    // feel for the ground
        //    DetectGround(); 
        //}

        //void OnDrawGizmos()
        //{
        //    Ray groundRay = new Ray(transform.position, Vector3.down);
        //    Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDistance);
        //}
        #endregion

        #region Custom Functions
        //void DetectGround()
        //{
        //    //create a ray going down
        //    Ray downRay = new Ray(transform.position, Vector3.down);
        //    //set hit to 2D Raycast
        //    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, Mathf.Infinity, groundLayer);
        //    //if hit collider is not null
        //    if (hit.collider != null)
        //    {
        //        //reset currentJump
        //        currentJump = 0;
        //    }
        //}

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Ground")
            {
                currentJump = 0;
            }
        } 

        void LimitVelocity()
        {
            //if rigid's velocity (magnitude) is greater than maxVelocity
            if (rigid.velocity.magnitude > maxVelocity)
            {
                //set rigid velocity to velocity normalized x maxVelocity
                rigid.velocity = rigid.velocity.normalized * maxVelocity;
            }
        }

        public void Jump()
        {
            //if currentJump is less than max jump
            if (currentJump < maxJumpCount)
            {
                //increment currentJump
                currentJump++;
                //add force to player (using impulse)
                rigid.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse); 
            }
           
        }
        
        public void Move(float horizontal)
        {
            //if horizontal > 0

            //flip character

            //if horizontal < 0;

            //flip character

            //add force to player in the right direction
            //rigid.AddForce(transform.right * horizontal * speed, ForceMode2D.Impulse);

            transform.position += new Vector3(horizontal, 0, 0) * Time.deltaTime * maxVelocity; 

            //limit velocity
            //LimitVelocity();
        }

        public void Climb(float vertical)
        {

        }

        #endregion
    }
}
