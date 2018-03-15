/*=============================================
-----------------------------------
Copyright (c) 2018 Yongli Wang
-----------------------------------
@file: UserInput.cs
@date: 12/03/2018
@author: Yongli Wang
@brief: Script to update PlayerController movement
===============================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand.Player
{
    [RequireComponent(typeof(PlayerController))]

    public class UserInput : MonoBehaviour
    {
        private PlayerController playerCon;
        private Animator anim;

        // Use this for initialization
        void Start()
        {
            playerCon = GetComponent<PlayerController>();
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            float inputH = Input.GetAxis("Horizontal");
            if (inputH != 0)
            {
                anim.SetBool("run", true);
                playerCon.Move(inputH);
            }
            else
            {
                anim.SetBool("run", false);
            }

            float inputV = Input.GetAxis("Vertical");
            if (inputV < 0 && !playerCon.onLadder)
            {
                anim.SetBool("crouch", true);
                playerCon.Climb(inputV);
            }
            else
            {
                anim.SetBool("crouch", false);
            }

            if (inputV != 0 && playerCon.onLadder)
            {
                playerCon.Climb(inputV);
            }
            if (!playerCon.onLadder)
            {
                anim.SetBool("climb", false);
            }

            if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("jump", true);
                playerCon.Jump();
            }
            else
            {
                anim.SetBool("jump", false);
            }
        }
    }
}
