using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostAttributes : MonoBehaviour {
	public float moveSpeed;
	public float jumpForce;
	public float special1CoolDown;
	public float special2CoolDown;


	public void special1() {
		// Do special ability 1
		Debug.Log(moveSpeed);
		// For Sticker Enemy: Stick to walls
	}

	public void special2() {
		// Do special ability 2
		Debug.Log(jumpForce);
		// For Sticker Enemy: Spawn a child
	}
}
