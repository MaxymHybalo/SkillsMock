using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmitter : MonoBehaviour {

	public GameObject particle;

	public int particles = 36;

	public int bottomIntensivity = 6;

	public int topIntensivity = 40;

	//Const for caclculation circle area
	public float R = 6f;

	private GameObject[] lights;

	void FixedUpdate(){

		FindAndDestroy (lights);

	}

	//params x,z used for randomize position around mouse's pointer
	public void InitParticles(float x, float z){ 
		lights = GameObject.FindGameObjectsWithTag ("Particle");
		for (int i = lights.Length; i < particles; i++)
			CreateNewParticle (particle, x, z);
	}

	private void CreateNewParticle(GameObject particle, float x, float z){
		Instantiate (particle);
		//particle.transform.position = new Vector3 (x, 0.5f, z);
		particle.transform.position = new Vector3 (GetCircularCoordinate(x), 0.5f, GetCircularCoordinate(z));
		particle.GetComponent<ParticleBehaviour > ().BOTTOM_INTENSIVITY = Random.Range (bottomIntensivity-3, bottomIntensivity);
		particle.GetComponent<ParticleBehaviour > ().TOP_INTENSIVITY = Random.Range (topIntensivity-10, topIntensivity);

	}

	private void FindAndDestroy(GameObject[] lights){
		lights = GameObject.FindGameObjectsWithTag ("Particle");		
		foreach (GameObject o in lights) {
			bool oState = o.GetComponent<ParticleBehaviour > ().cycle;
			if (oState) {
				Destroy (o);
			}
		}
	}

	private float GetCircularCoordinate(float center){
		float random = Random.Range (0f, R);

		return Random.Range (center - R/2, center + R/2);
	}

}
