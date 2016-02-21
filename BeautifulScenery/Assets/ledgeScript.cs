using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class ledgeScript : MonoBehaviour {

    private bool check;
    private AudioSource ads;

    // Use this for initialization
    void Start () {
        check = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (!check && !onledge())
        {
            Debug.Log("yeeeeeee\n");
            ads.enabled = !ads.enabled;
            check = true;
        }

    }

    bool onledge()
    {
        if (GameObject.Find("FPSController").transform.position.z < GameObject.Find("Cube").transform.position.z - 2 - GameObject.Find("Cube").transform.localScale.z / 2)
        {
            Debug.Log("number: " + (GameObject.Find("Cube").transform.position.z - 2 - GameObject.Find("Cube").transform.localScale.z / 2));
            return false;
        }
        return true;
    }
}
