using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DistanceToPlanet : MonoBehaviour
{
    public GameObject displayDistanceToPlanet;
    //220-117
    public int disToPlanet = 100;
    public bool addingDist = false;

    // Update is called once per frame

    
    void Update()
    {
        if (!addingDist)
        {
            addingDist = true;
            StartCoroutine(AddingDist());
        }
    }

    IEnumerator AddingDist()
    {
        disToPlanet -= 2;

        // Assuming DisplayDistancetoPlanet is a Text component, use text property to set the value
        displayDistanceToPlanet.GetComponent<Text>().text = "Distance: " + disToPlanet;

        yield return new WaitForSeconds(1f);

        addingDist = false;
    }
}
