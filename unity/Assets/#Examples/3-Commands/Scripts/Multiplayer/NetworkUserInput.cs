using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;

namespace Commands
{
    [RequireComponent(typeof(PlayerController))]
    public class NetworkUserInput : NetworkBehaviour
    {
        public Camera cam;  //client's camera
        public AudioListener aud;  //client's audiolistener

        [SyncVar]
        public float inputH, inputV;
        [SyncVar]
        public float mouseX, mouseY;

        private PlayerController player;

        #region Unity Functions
        // Use this for initialization
        void Start()
        {
            player = GetComponent<PlayerController>();
            //if is local player then value=true, if not value=false
            cam.enabled = isLocalPlayer;
            aud.enabled = isLocalPlayer;
        }

        // Update is called once per frame
        void Update()
        {
            if (isLocalPlayer)
            {
                GetInput();
                player.Move(inputH, inputV);
                player.Look(mouseX, mouseY);
                //send input across network
                Cmd_Move(inputH, inputV);
                Cmd_Look(mouseX, mouseY);
            }
        }
        #endregion

        #region Custom Functions
        void GetInput()
        {
            inputH = Input.GetAxis("Horizontal");
            inputV = Input.GetAxis("Vertical");
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");
        }
        #endregion

        #region Commands
        // Functions that are called from clients to run on the server
        [Command]
        void Cmd_Move(float inputH, float inputV)
        {
            Rpc_Move(inputH, inputV);
        }
        [Command]
        void Cmd_Look(float mouseX, float mouseY)
        {
            Rpc_Look(mouseX, mouseY);
        }
        #endregion

        #region Remote Procedure Calls (RPCs)
        // Functions that are called from the server and run on each client
        [ClientRpc]
        void Rpc_Move(float inputH, float inputV)
        {
            player.Move(inputH, inputV);
            //print(name + " is called by RPC!"); //this will cause lagging
        }

        [ClientRpc]
        void Rpc_Look(float mouseX, float mouseY)
        {
            player.Look(mouseX, mouseY);
            //print(name + " is called by RPC!"); //this will cause lagging
        }

        #endregion
    }
}
