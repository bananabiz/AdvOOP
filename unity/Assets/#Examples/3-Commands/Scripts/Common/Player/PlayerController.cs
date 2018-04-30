using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Commands
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float lookSpeed = 5f;
        public float maxVelocity = 5f;
        [Header("References")]
        public Transform attachedCamera;

        // Private References
        private Rigidbody rigid;
        private float inputH, inputV;
        private float mouseX, mouseY;

        
        #region Unity Functions
        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            LimitVelocity();
            PerformMove();
            PerformLook();  
        }
        #endregion

        void PerformMove()
        {
            Vector3 inputDir = new Vector3(inputH, 0, inputV);

            float yDegrees = transform.eulerAngles.y;
            Quaternion localRotation = Quaternion.Euler(0, yDegrees, 0);
            inputDir = localRotation * inputDir;

            rigid.velocity = inputDir * moveSpeed;
        }

        void PerformLook()
        {
            // Rotate Player on the "Horizontal" axis
            Vector3 euler = transform.eulerAngles;
            euler.y += mouseX * lookSpeed * Time.deltaTime;
            transform.eulerAngles = euler;
            // Rotate Camera on the "Vertical" axis
            Vector3 camEuler = attachedCamera.localEulerAngles;
            camEuler.x -= mouseY * lookSpeed * Time.deltaTime;
            attachedCamera.localEulerAngles = camEuler;
        }
        
        #region Custom Functions
        void LimitVelocity()
        {
            Vector3 vel = rigid.velocity;
            if(vel.magnitude > maxVelocity)
            {
                vel = vel.normalized * maxVelocity;
            }
            rigid.velocity = vel;
        }

        public void Look(float horizontal, float vertical)
        {
            mouseX = horizontal;
            mouseY = vertical;
            //perform any delegate actions here
        }
        public void Move(float horizontal, float vertical)
        {
            inputH = horizontal;
            inputV = vertical;
            //perform any delegate actions here
        }
        #endregion
    }
}
