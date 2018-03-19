/*=============================================
-----------------------------------
Copyright (c) 2018 Yongli Wang
-----------------------------------
@file: Opossum.cs
@date: 16/03/2018
@author: Yongli Wang
@brief: Script to control opossum movement
===============================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand
{
    public class Opossum : MonoBehaviour
    {
        public float speed = 1.5f;
        public float lineOffset = 0.3f; //make the line shorter base on the thickness of ground

        private float halfWidth;
        private int rotation = 0;
        private RaycastHit2D leftHit, rightHit;
        private bool isGounded;
        private Rigidbody2D myRigid;

        void Start()
        {
            myRigid = GetComponent<Rigidbody2D>();
            // get this game object's half width
            halfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        }

        void FixedUpdate()
        {
            Vector3 pos = transform.position;
            Vector2 lineCastPos = pos - transform.right * halfWidth;  //transform's left edge
            Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down * lineOffset);
            //check if there's ground in front of us
            isGounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down * lineOffset);

            //turn around if there's no ground
            if (!isGounded)
            {
                rotation += 180;
                transform.rotation = Quaternion.AngleAxis(rotation, Vector3.up);
            }
            
            //move forward
            Vector2 myVelocity = myRigid.velocity;
            myVelocity.x = -transform.right.x * speed;
            myRigid.velocity = myVelocity;  
        }

    }
}
