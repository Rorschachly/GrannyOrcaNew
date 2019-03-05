using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using OVRInput;

public class CustomControllerSetting : MonoBehaviour {
    public GameObject gameob;
    public Material init;
    public Material down;
    public Material selected;

    // Use this for initialization
    void Start () {
        Debug.Log("Started");
	}
	
	// Update is called once per frame
	void Update () {
        OVRInput.Update();

        Debug.Log(OVRInput.Get(OVRInput.Button.One));
        Debug.Log(OVRInput.GetDown(OVRInput.Button.One));
        Debug.Log(OVRInput.GetUp(OVRInput.Button.One));
        if (OVRInput.Get(OVRInput.Button.One))
        {
            Debug.Log("button A pressed");
        }

        if(OVRInput.Get(OVRInput.Button.Two))
        {
            Debug.Log("button B pressed");
        }

        if (OVRInput.Get(OVRInput.Button.Three))
        {
            Debug.Log("button X pressed");
        }

        if (OVRInput.Get(OVRInput.Button.Four))
        {
            Debug.Log("button Y pressed");
        }

        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
        {
            Debug.Log("button Left trigger pressed");
        }

        if(OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            Debug.Log("button Right trigger pressed");
        }
    }
}
