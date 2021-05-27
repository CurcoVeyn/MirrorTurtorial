using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    // Start is called before the first frame update

    void HandleMovement()
    {
        if (isLocalPlayer) // Si es el jugador que que controla la maquina
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal * 0.1f, moveVertical * 0.1f, 0);
            transform.position = transform.position + movement;
        }
    }

      void Update()
    {
        HandleMovement();

        if (isLocalPlayer && Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Sending HolaServidor to de Server from player:" + this);
            Hola();
        }

        if (isServer && transform.position.y > 50)
        {
            // ToHigh();
        }

    }
    /**[ClientRpc] CLIENTRPC to Communicate to ALL CLIENTS
    void ToHigh()
    {

        Debug.Log("To High");

    }**/

    [Command] // Command to comunicate to a SERVER
    void Hola()
    {
        Debug.Log("Recived HolaServidor from Client :" + this);
        ReplyHola();
    }

    [TargetRpc] // TARGETRPC to comunicate to SPECIFIC CLIENT
    void ReplyHola()
    {
        
        Debug.Log("Recived HolaCliente From Server");
    }

  
    /**WHAT CAN BE COMUNICATED
        Primitives(byte,in, float, stings, etc)
        Built in Unity math(Vector3, Quaternion, etc)
        Arrays of Primituve Types 
        Structure w/ these Types
        NeworkIdentities
        GameObjects w/ NetworkIdentities
      **/  

}
