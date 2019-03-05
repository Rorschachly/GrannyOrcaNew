using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour {

    private bool hold;
    private Collider rightHand;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (hold)
        {
            stickOnToFlipper();
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Contact Player from hold");
            hold = true;
            rightHand = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hold = false;
            rightHand = other;
        }
    }

    private void stickOnToFlipper()
    {
        this.transform.position = rightHand.transform.position;
    }
}
