using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_move_up_down : MonoBehaviour
{
    [SerializeField] [Range(0,1)] float speed = 0.5f;
    // slider fyirr að breyta value á hraða
    [SerializeField] [Range(0,100)] float range = 9f; 
    // slider fyirr að breyta value á range
     void Update()
     {
         loop();
         // til að loopa fallið
     }
 
      void loop()
     {
        // til að láta færa upp og niður með sérstakri math formúlu
        float yPos = Mathf.PingPong(Time.time * speed, 1) * range;
        // og færir hlutinn
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
     }
}
