using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatDetect : MonoBehaviour {

    public GameObject granny_swim;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fish"))
        {
            Debug.Log("Eat");
            granny_swim.GetComponent<Granny_Behavior>().chewing.Play();
            granny_swim.GetComponent<Granny_Behavior>().EatenAndCelebration();
        }
    }

    private void OnTriggerExit(Collider other)
    {

    }
}
