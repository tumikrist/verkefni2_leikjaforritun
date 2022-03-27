using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerFollower : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    // hvar player er
    public Vector3 offset;
    // til að hafa myndavélina smá frá
    private Space offsetPositionSpace = Space.Self;
    private bool lookAt = true;
    // Update is called once per frame
    void Update()
    {
        if (offsetPositionSpace==Space.Self)
        {
            transform.position =player.TransformPoint(offset);
            // fyrir transfer
        }
        else
        {
           transform.position = player.position + offset;
           // fyrir myndavél
  
        }

        // compute rotation
        if (lookAt)
        {
            transform.LookAt(player);
            // passa upp á með að snúa
        }
        else
        {
            transform.rotation = player.rotation;
            // fyrir að rotationið á myndavél
        }

    }
  
}

