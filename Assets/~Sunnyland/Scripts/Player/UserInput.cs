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

        // Use this for initialization
        void Start()
        {
            playerCon = GetComponent<PlayerController>();
        }

        // Update is called once per frame
        void Update()
        {
            float inputH = Input.GetAxis("Horizontal");
            playerCon.Move(inputH);
            float inputV = Input.GetAxis("Vertical");
            playerCon.Climb(inputV);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerCon.Jump();
            }
        }
    }
}
