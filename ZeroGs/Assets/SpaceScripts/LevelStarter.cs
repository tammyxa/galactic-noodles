using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public GameObject info;
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countDownGo;
    void Start()
    {
        StartCoroutine(CountSequence());
    }

    IEnumerator CountSequence(){
        yield return new WaitForSeconds(.5f);
        info.SetActive(true);
        yield return new WaitForSeconds(2.75f);
        countDown3.SetActive(true);

        yield return new WaitForSeconds(1);
        countDown2.SetActive(true);

        yield return new WaitForSeconds(1);
        countDown1.SetActive(true);

        yield return new WaitForSeconds(1);
        countDownGo.SetActive(true);

        PlayerSpaceShip.canMove = true;

    }
}
