using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour {

	//Llista d'elements que la camera seguira
	public List<Transform> targets;
	//valor que ens ajudara a posar la camera a lloc
	public Vector3 offset;
	public float smoothTime = .5f;
	public float minZoom = 40f;
	public float maxZoom = 10f;
	public float zoomLimiter = 50f;

	private Vector3 velocity;
	private Camera cam;

	void Start(){
		cam = GetComponent<Camera> ();
	}

	//Update que es fa despres dels altres updates
	//per tal de que la camera es mogui despres de que ho facin els targets
	void LateUpdate(){
		if (targets.Count != 0) {
			Move ();
			Zoom ();
		}
	}


	//repassar part del zoom
	void Zoom(){
		//volem agafar el valor maxim entre els diferents targets
		//aixi hi entraran tots
		float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance()/zoomLimiter);
		cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
	}

	float GetGreatestDistance(){
		var bounds = new Bounds(targets[0].position, Vector3.zero);

		for (int i = 0; i < targets.Count; i++) {
			bounds.Encapsulate (targets[i].position);
		}

		return bounds.size.x;
	}

	//Funcio per moure la camera
	void Move(){
		//vector de posicio generat per els diferents elements
		Vector3 centerPoint = GetCenterPoint ();
		//li afegim l'offset perque quedi millor
		Vector3 newPosition = centerPoint + offset;
		//Movemm la camera amb el metode smooth perque quedi mes bonic
		// donant la posicio inicial, la final, la velocitat i el temps que tarda a moure a la nova posicio
		transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
	}
		
	Vector3 GetCenterPoint(){
		//En cas de que nomes hi hagi un target, retornem la seva posicio
		if (targets.Count == 1) {
			return targets [0].position;
		}

		//BOUNDS: unio de diferents elements en una caixa imaginaria que ens crea diferents valors
		//En aquest cas agafem el centre de la caixa que sera el punt mig entre els dos o mes elements.
		var bounds = new Bounds(targets[0].position, Vector3.zero);
		//Afegim cada element a la visió de la camera
		for (int i = 0; i < targets.Count; i++) {
			bounds.Encapsulate (targets [i].position);
		}
		//retornem el centre del BOUNDS
		return bounds.center;
	} 
}
