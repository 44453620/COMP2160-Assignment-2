using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    private float driveSpeed;
    public float rotateSpeed;
    public float acceleration;
    private float brake = 100;
    private float maxSpeed = 150;
    private float normalSpeed = 60f;
    private float turboSpeed = 100f;
    enum TurboState
    {
        Available, Active, Cooldown
    };
    private TurboState turboState;
    private float turboDuration = 10;
    public float cooldownDuration = 5;
    private float turboTimer = 0;

    void Start()
    {
        turboState = TurboState.Available;       
    }

    void Update()
    {
      //driveSpeed = normalSpeed;
      switch(turboState)
        {
          case TurboState.Available:
              // driveSpeed = normalSpeed; 
               if(Input.GetButtonDown("Turbo"))
               {
                   turboState = TurboState.Active;
                   driveSpeed = turboSpeed;
                   turboTimer = turboDuration;
               }
               break;

          case TurboState.Active:
               driveSpeed = turboSpeed;
               turboTimer -= Time.deltaTime;
               if(turboTimer <= 0)
               {
                   turboState = TurboState.Cooldown;
                   driveSpeed = normalSpeed;
                   turboTimer = cooldownDuration;
               }
               break;
        
          case TurboState.Cooldown:
               driveSpeed = normalSpeed;
               turboTimer -= Time.deltaTime;
               if(turboTimer <= 0)
               {
                   turboState = TurboState.Available;
               }
               break;
        }

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

      //  driveSpeed = Mathf.Clamp(driveSpeed, -maxSpeed, maxSpeed);  

        transform.Translate(driveSpeed * Time.deltaTime * Vector3.forward);  
        Vector3 velocity = Vector3.forward * driveSpeed;

        float turn = Input.GetAxis("Horizontal");
        transform.Rotate (0, turn*rotateSpeed*Time.deltaTime, 0);

    } 
}




