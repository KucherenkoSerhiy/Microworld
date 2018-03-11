using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Class for enemies that follow the player
/// Must create option for which player to follow.
public class PursuerEnemy : BaseEnemy {
	public Transform target;
	void FixedUpdate(){
		target = GameObject.FindWithTag("Player1").transform;
	}

	void Start () {
		//theRB = GetComponent<Rigidbody2D> ();
		transform.eulerAngles = new Vector3 (0f, 0f, transform.eulerAngles.z);
	}

	void Update () {
		// Move towards the player
		transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed*Time.deltaTime);
		transform.eulerAngles = new Vector3 (0f, 0f, transform.eulerAngles.z);
	}
}
