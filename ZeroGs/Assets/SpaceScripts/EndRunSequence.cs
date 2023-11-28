using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndRunSequence : MonoBehaviour
{

    public GameObject fadeOut;
    public GameObject endScreen;
    public ShipHealthManager playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndSequence());
        Debug.Log("Start method in EndRunSequence called");
        

    }

    // Update is called once per frame
    IEnumerator EndSequence(){
        Cursor.lockState = CursorLockMode.None;
        yield return new WaitForSeconds(2);
        endScreen.SetActive(true);
        yield return new WaitForSeconds(2);

        // Activate the fadeOut object
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);




    }
}
