using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionTrackerManager : MonoBehaviour
{

    public Animator animator;

    public void OpenTracker ()
	{
		animator.SetBool("IsOpen", true);
	}

	public void CloseTracker ()
	{
		animator.SetBool("IsOpen", false);

	}
}
