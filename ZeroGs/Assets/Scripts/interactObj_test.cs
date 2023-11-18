using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactObj_test : MonoBehaviour
{
    private float meter = 0f;
    private bool isInteracting = false;
    public void interaction(bool m)
    {
        isInteracting = m;
    }

    public float getMeter() {return meter;}

    void Update()
    {
        if (isInteracting)
            meter += 0.5f;
        meter = meter <= 0f ? 0f : meter - 0.2f;
    }
}