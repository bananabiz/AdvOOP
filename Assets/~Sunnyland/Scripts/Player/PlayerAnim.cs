using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand
{
    [RequireComponent(typeof(PlayerController))]
    [RequireComponent(typeof(Animator))]

    public class PlayerAnim : MonoBehaviour
    {
        private PlayerController1 player;
        private Animator anim;

        // Use this for initialization
        void Start()
        {
            anim = GetComponent<Animator>();
            player = GetComponent<PlayerController1>();
            player.onGroundedChanged += OnGroundedChanged; 
        }

        // Update is called once per frame
        void OnGroundedChanged(bool isGrounded)
        {
            if (isGrounded)
            {
                print("I'm grounded :(");
            }
            else
            {
                print("I'm not grounded :)");
            }
        }
    }
}
