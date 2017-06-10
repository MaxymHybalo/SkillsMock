using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseObserver : MonoBehaviour {

	//variables which represent field coorinates through mouse position
	private float x;
	private float z;

	void Update () {
		if (Input.GetMouseButton (0)) {
			InitXY (Input.mousePosition);
			ParticleEmitter emitter = GameObject.Find ("Emitter").GetComponent<ParticleEmitter> ();
			emitter.InitParticles (x,z);
		}

	}

	private void InitXY(Vector3 mousePosition){
		x = ((mousePosition.y * 36) / Screen.height - 18);
		z = ((mousePosition.x * 80) / Screen.width - 40) * -1;
		Debug.Log (x + " " + z);
	}

}
