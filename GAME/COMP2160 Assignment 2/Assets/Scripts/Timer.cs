using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;

    private float second;
    private float minute;
    private float milisecond;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        minute =(int)(Time.time/60f);
        second = (int)(Time.time%60f);
        milisecond = (int)(Time.timeSinceLevelLoad * 100f) % 100; 
        timer.text = "Time: " + minute.ToString("00") + ":" + second.ToString("00") + ":" + milisecond.ToString("00");
    }
}
