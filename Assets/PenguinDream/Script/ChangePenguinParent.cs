using UnityEngine;
using System.Collections;

public class ChangePenguinParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        other.transform.parent = GameObject.Find("ice").transform;
        other.transform.rigidbody.isKinematic = true;
    }
}
