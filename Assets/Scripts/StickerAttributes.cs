using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerAttributes : MonoBehaviour {
	public float moveSpeed;
	public float jumpForce;
	public float special1CoolDown;
	public float special2CoolDown;

	// Use this for initialization
	void Start () {
		// Initialize all variables here
		moveSpeed = 1;
		jumpForce = 2;
		special1CoolDown = 0; // Can use Special 1 anytime
		special2CoolDown = 3; // 3 Seconds until we can spawn another enemy
	}
	
	public void special1() {
		Debug.Log ("STICKING");
		// Do special ability 1
		// For Sticker Enemy: Stick to walls
	}

	public void special2() {
		// Do special ability 2
		Debug.Log ("SPAWNING");
		// For Sticker Enemy: Spawn a child
	}
}
