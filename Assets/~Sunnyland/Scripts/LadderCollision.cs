/*=============================================
-----------------------------------
Copyright (c) 2018 Yongli Wang
-----------------------------------
@file: LadderCollision.cs
@date: 15/03/2018
@author: Yongli Wang
@brief: Script to detect if player collide with ladders
===============================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand
{
    public class LadderCollision : MonoBehaviour
    {
        private PlayerController playerCon;

        // Use this for initialization
        void Start()
        {
            playerCon = FindObjectOfType<PlayerController>(); 
        }
        // detect if player is within the ladder
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.name == "Player")
            {
                playerCon.onLadder = true;
            }
        }
        // detect if player leaves the ladder
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.name == "Player")
            {
                playerCon.onLadder = false;
                other.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        } 
    }
}
