using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Possession : MonoBehaviour {


	void OnCollisionStay2D(Collision2D coll) {
		if (coll.collider.tag == "Enemy") {
			if (gameObject.tag == "Player1") {
				// WILL IMPLEMENT HOST INVASION HERE. WILL BE CHANGED IN THE FUTURE
				// FROM "ON COLLISION" TO "ON COLLISION WITH PROJECTILE"

				// guardar atributos del enemigo
				//componenteatributos = coll.gameObject.myvariable;

				// destruir enemigo
				// Get Enemy Type


				// Get name of Enemy and Destroy the component
				// GameObject name == Component Game
				string enemyType = coll.gameObject.name;
				Destroy (coll.gameObject.GetComponent (enemyType));



				//Destroy(coll.gameObject.GetComponent("PursuerEnemy"));

				// crear componente player solitario
				Debug.Log("POSSESSING");
				coll.gameObject.AddComponent (typeof(PlayerController));
				coll.gameObject.AddComponent (typeof(HostController));
				coll.gameObject.AddComponent (typeof(HostAttributes));

				// This is super clunky.
				// How can we do it without writing the names?
				// The problem is that I have to actually write coll.gameObject.GetComponent<StickerEnemy>()
				// If somebody can come up with a better solution, c00l
				// Remember:
				// 		We have the name "StickerEnemy" in the variable "enemyType"
				//		All the Attributes follow the form "StickerAttributes"
				//      We could create this string from enemyType easily
				//      
				// Another thing we could do is have two classes:
				// One for every enemy type: StickerEnemy/JumpingEnemy,etc
				// Another one for the Host with the same attributes
				// When possessing the enemy we READ the StickerEnemy/JumpingEnemy attributes,
				// add the HOSTAttributes component to the gameObject and then COPY all the variables
				// from StickerEnemy to HOSTAttributes manually here. ALso, override the methods.
				// We would still need a massiv IF ELSE loop, but everything should work, no?
				// WATDAYUZINK?

				// For now:
				// We can make the HostController HAVE the attributes of the StickerEnemy stored in the variable hAttributes
				// I don't know how to override the functions so that hAttribute.special1() does the same as eattr.special1()

				if (enemyType == "StickerEnemy") {
					Debug.Log(coll.gameObject.GetComponent<HostController>().hAttributes);
					//coll.gameObject.GetComponent<HostController>().hAttributes = coll.gameObject.GetComponent<StickerAttributes>();
					HostAttributes hattr;
					coll.gameObject.GetComponent<HostController>().hAttributes = coll.gameObject.GetComponent<HostAttributes>();
					hattr = coll.gameObject.GetComponent<HostController>().hAttributes;
					StickerAttributes eattr;
					eattr = coll.gameObject.GetComponent<StickerAttributes>();

					hattr.moveSpeed = eattr.moveSpeed;
					hattr.jumpForce = eattr.jumpForce;
					hattr.jumpForce = eattr.jumpForce;

					// Override methods here...
					Debug.Log(coll.gameObject.GetComponent<HostController>().hAttributes);


				}
				// Get tag with type of enemy


				coll.collider.tag = "Player2";

			}
		}
	}


				


	
}
