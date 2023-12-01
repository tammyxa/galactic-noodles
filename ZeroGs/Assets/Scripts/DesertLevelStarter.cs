using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertLevelStarter : MonoBehaviour
{
    public GameObject info;
    void Start()
    {
        StartCoroutine(CountSequence());
    }

    IEnumerator CountSequence(){
        yield return new WaitForSeconds(.5f);
        info.SetActive(true);
    }
}
