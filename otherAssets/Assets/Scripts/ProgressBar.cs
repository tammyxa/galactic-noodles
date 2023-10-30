using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


public class ProgressBar : MonoBehaviour
{
    public float displayPercent = 1f;
    public Slider fillBar;

    private float lastActiveTime;

    void Awake()
    {
        lastActiveTime = Time.fixedTime;
    }

    void Update()
    {
        if (displayPercent >= 1f || displayPercent < 0.01f) {
            this.GetComponent<Canvas>().enabled = false;
            return;
        }

        if (fillBar.value != displayPercent)
        {
            this.GetComponent<Canvas>().enabled = true;
            lastActiveTime = Time.fixedTime;
            fillBar.value = displayPercent;
        }
        else if (Time.fixedTime - lastActiveTime >= 3f)
        {
            this.GetComponent<Canvas>().enabled = false;
        }
    }
}