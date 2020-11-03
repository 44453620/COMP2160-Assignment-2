using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float driveSpeed;
    public float rotateSpeed;
    private float acceleration = 100.0f;
    private float brake = 100.0f;
    private float maxSpeed = 15.0f;
    private float forward;
    private float turn;

    void Update()
    {
       forward = Input.GetAxis("Vertical");
      if (forward > 0) 
      {
        driveSpeed += acceleration * Time.deltaTime;
      }
      else if (forward < 0) 
      {
        driveSpeed -= acceleration * Time.deltaTime;
      }
      else 
      {
         while(driveSpeed != 0)
         {  
             driveSpeed -= brake * Time.deltaTime;
         }
      }
      driveSpeed = Mathf.Clamp(driveSpeed, -maxSpeed, maxSpeed); 
      Vector3 velocity = Vector3.forward * driveSpeed;
      transform.Translate(velocity * Time.deltaTime);  

      if(forward == 0)
      {
          turn = 0;
      }
      else
      {
          turn = Input.GetAxis("Horizontal");
      }
      transform.Rotate (0, turn*rotateSpeed*Time.deltaTime, 0);
    } 
}




