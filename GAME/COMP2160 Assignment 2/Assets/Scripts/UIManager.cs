using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{   
    public static UIManager instance;

    public Text timer;

    private TimeSpan time;
    private bool timeActive;

    private float elapsed;

     void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timer.text = "Time: 00:00:00";
        timeActive = false;
    }

    public void StartTimer()
    {
        timeActive = true;
        elapsed = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timeActive = false;
    }

    private IEnumerator UpdateTimer()
    {
        while(timeActive)
        {
            elapsed += Time.deltaTime;
            time = TimeSpan.FromSeconds(elapsed);
            string timePlaying = "Time:" + time.ToString("mm' : 'ss' : 'ff");
            timer.text = timePlaying;

            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
