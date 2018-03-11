using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Class for a PARTICULAR type of enemy
/// This enemy sticks to Player1, impedes his movement and
/// acts as an Enemy generator. It is like a ""virus""
/// replicating as long as it is in contact with Player1.
public class EnemySticker : PursuerEnemy {
	private EnemyGenerator spawner;
	private bool isStuck = false;
	private float playerMoveSpeed;
	private float spawnTime = 3f; // How long between each spawn.
	public bool isParent = true; // Defines if gameObject is able to reproduce
	public GameObject child;   // Contains instance to created child enemy

	// Impedes his movement and jumping
	void StickToTarget() {
		// Makes player movement half of what it was
		// Almost Removes ability to jump
		playerMoveSpeed = GameObject.FindWithTag("Player1").GetComponent<PlayerController>().moveSpeed;
		GameObject.FindWithTag ("Player1").GetComponent<PlayerController>().jumpForce = 0.5f;
		GameObject.FindWithTag("Player1").GetComponent<PlayerController>().moveSpeed = playerMoveSpeed / 2;
	}

	// Spawn a child StickerEnemy without the ability to reproduce itself
	void Spawn() {
		child = Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation);
		child.GetComponent<StickerEnemy>().isParent = false;
	}


	// Override die() function to destroy the EnemyGenerator first
	// Are there @decorators like in python in this joke of programming language?
	void die() {
		// destroy (spawner);
		// Do the dying here
		//Destroy(spawner);
		//Destroy(GameObject);
	}

	// Checks if collision with player and acts accordingly
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject == GameObject.FindWithTag("Player1")) {
			Debug.Log("P1!!");

			// Collision with player
			// Must do 2 things:
			// 	- Stick to it eternally
			//  - Start spawning childs
			if (isStuck == false) {
				isStuck = true;
				StickToTarget();
				// Only reproduce if it is a parent
				if (isParent) {
					InvokeRepeating ("Spawn", spawnTime, spawnTime);
				}
			}
		}
	}

}
