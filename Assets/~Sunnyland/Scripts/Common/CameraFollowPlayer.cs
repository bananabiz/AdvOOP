/*=============================================
-----------------------------------
Copyright (c) 2018 Yongli Wang
-----------------------------------
@file: PlayerController.cs
@date: 15/03/2018
@author: Yongli Wang
@brief: Script to control camera move with player
===============================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand.Player
{
    public class CameraFollowPlayer : MonoBehaviour
    {
        public Transform player;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = player.position + new Vector3(1.2f, 0.5f, -10f);
            //transform.position = Vector3.Lerp(transform.position, player.position, 5.0f * Time.deltaTime) + new Vector3(1.2f, 0.5f, -10f);
        }

    }
}