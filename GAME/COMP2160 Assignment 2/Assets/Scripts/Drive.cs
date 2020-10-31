using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    private float driveSpeed;
    public float speed;
    public float rotateSpeed;
    private float acceleration = 100.0f;
    private float brake = 10.0f;
    private float maxSpeed = 15.0f;

    void Update()
    {
      float forward = Input.GetAxis("Vertical");
      if (forward > 0) {
        driveSpeed += acceleration * Time.deltaTime;
      }
      else if (forward < 0) {
        driveSpeed -= acceleration * Time.deltaTime;
      }
      else {
        if(driveSpeed > 0) {
            driveSpeed -= brake * Time.deltaTime;
        }
      }
      driveSpeed = Mathf.Clamp(driveSpeed, -maxSpeed, maxSpeed); 
      speed = driveSpeed;
      Vector3 velocity = Vector3.forward * driveSpeed;
      transform.Translate(velocity * Time.deltaTime);  

      float turn = Input.GetAxis("Horizontal");
      transform.Rotate (0, turn*rotateSpeed*Time.deltaTime, 0);
    } 
}




