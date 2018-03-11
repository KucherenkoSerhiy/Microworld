using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostController : MonoBehaviour {
	public HostAttributes hAttributes;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("q")) {
			Debug.Log ("Special1");
			hAttributes.special1 ();
			//Debug.Log (eAttributes);
			// Special ability 1
			//eAttributes.special1();
		}

		if (Input.GetKey("e")) {
			Debug.Log ("Special2");
			hAttributes.special2 ();
			//eAttributes.special2();
			// Special ability 2
		}

	}
}
