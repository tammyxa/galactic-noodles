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

    void Awake()
    {
        this.winUi.SetActive(false);
    }

    void Update()
    {
        buildBar.value = launchPad.buildProgress / launchPad.requiredBuild;
    }

    public void ShowWinState(bool show=true)
    {
        this.winUi.SetActive(show);
    }
}