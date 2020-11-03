using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public LayerMask layer;
    public GameObject camera;

    private  float timePressed = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float speed = GameObject.Find("Car").GetComponent<Drive>().driveSpeed;

        Ray ray = new Ray(target.position, Vector3.down);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
        {
            transform.position = hit.point;
        }
        
        if(speed > 5)
        {
            speed = 5;
        } 
        else if (speed < 0)
        {
            speed = 0;
        }

        camera.transform.position = transform.TransformPoint(0,1, -2-speed);

        float turning = Input.GetAxis("Horizontal") * Time.deltaTime * GameObject.Find("Car").GetComponent<Drive>().rotateSpeed;
        float savedTime = 0;

        if (turning != 0)
        {   
            savedTime = timePressed;
            timePressed += Time.deltaTime;
        }
        else
        {   
            
            timePressed = 0;
        }

        if (savedTime >= 1)
        {
        transform.Rotate(0, turning, 0);
        }
        Debug.Log(savedTime);
    }
}
