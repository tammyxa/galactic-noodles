using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static PlayerInput;
using static PlayableObject;
using static LaunchPad;


public class MainUiHandler : MonoBehaviour
{
    public Slider buildBar;
    public GameObject winUi;
    public LaunchPad launchPad;

    public Text countdownText;

    void Awake()
    {
        this.winUi.SetActive(false);
    }

void Update()
{
    buildBar.value = launchPad.buildProgress / launchPad.requiredBuild;

    // Countdown logic
    int countdownValue = Mathf.CeilToInt(20 - (buildBar.value * 20));
    countdownText.text = "Scrap Needed to repair launchpad:" + countdownValue;

    if (countdownValue <= 0)
    {
        ShowWinState(true);
    }
}

    public void ShowWinState(bool show=true)
    {
        this.winUi.SetActive(show);
    }
}