using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmitter : MonoBehaviour {

	public GameObject particle;

	public int particles = 36;

	public int bottomIntensivity = 6;

	public int topIntensivity = 40;


	private GameObject[] lights;

	void Start () {
		for (int i = 0; i <= particles; i++) {
			CreateNewParticle (particle);
		}
	}

	void FixedUpdate(){
		lights = GameObject.FindGameObjectsWithTag ("Particle");
		FindAndDestroy (lights);
	}

	void Update(){
		lights = GameObject.FindGameObjectsWithTag ("Particle");
		if (lights.Length <= particles) {
			CreateNewParticle (particle);
			for (int i = lights.Length; i < particles; i++)
				CreateNewParticle (particle);
		}
	}

	private void CreateNewParticle(GameObject particle){
		Instantiate (particle);
		particle.transform.position = new Vector3 (Random.Range(-18,18), 0.5f, Random.Range(-40,40));
		particle.GetComponent<ParticleBehaviour > ().BOTTOM_INTENSIVITY = Random.Range (bottomIntensivity-3, bottomIntensivity);
		particle.GetComponent<ParticleBehaviour > ().TOP_INTENSIVITY = Random.Range (topIntensivity-10, topIntensivity);

	}

	private void FindAndDestroy(GameObject[] lights){
		foreach (GameObject o in lights) {
			bool oState = o.GetComponent<ParticleBehaviour > ().cycle;
			if (oState) {
				Destroy (o);
			}
		}
	}

}
