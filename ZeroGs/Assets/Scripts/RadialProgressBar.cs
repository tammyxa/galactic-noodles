using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


public class RadialProgressBar : MonoBehaviour
{
    public float displayPercent = 1f;
    public Image fillImage;

    private float lastActiveTime;

    void Awake()
    {
        lastActiveTime = Time.fixedTime;
    }

    void Update()
    {
        if (displayPercent >= 1f || displayPercent < 0.01f)
        {
            this.GetComponent<Canvas>().enabled = false;
            return;
        }

        if (fillImage.fillAmount != displayPercent)
        {
            this.GetComponent<Canvas>().enabled = true;
            lastActiveTime = Time.fixedTime;
            fillImage.fillAmount = displayPercent;
        }
        else if (Time.fixedTime - lastActiveTime >= 1.5f)
        {
            this.GetComponent<Canvas>().enabled = false;
        }
    }
}