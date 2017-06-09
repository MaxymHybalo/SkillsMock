using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour {

	public float delta = 0.2f;
	public float TOP_INTENSIVITY = 20f;
	public float BOTTOM_INTENSIVITY = 3f;
	public bool cycle = false; //Flag which indicate when object can destroy

	private bool loop = false;


	void Update () {
		Light dynamic = this.GetComponent<Light> ();
		float intensity = dynamic.intensity;
		if (intensity <= TOP_INTENSIVITY && loop == false) {
			dynamic.intensity+=delta;
		}
		if (intensity > TOP_INTENSIVITY) {
			loop = true;
		}
		if (loop && intensity >= BOTTOM_INTENSIVITY) {
			dynamic.intensity-=delta;
		}
		if (intensity < BOTTOM_INTENSIVITY) {
			loop = false;
			cycle = true;

		}
	}
}
