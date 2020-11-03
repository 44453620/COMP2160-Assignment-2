using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{   
    public static UIManager instance;

    public RectTransform bar;
    public GameObject Car;
    public GameObject GameOverPanel;

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

    }

    // Update is called once per frame
    void Update()
    {
       float hp = Car.GetComponent<Health>().getHealth;
       bar.sizeDelta = new Vector2 ((hp*7), 13);
    }

    public void OverPanelOn()
    {
        GameOverPanel.SetActive(true);
    }

    public void OverPanelOff()
    {
        GameOverPanel.SetActive(false);
    }
}
