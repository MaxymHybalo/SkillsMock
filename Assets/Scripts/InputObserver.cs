using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputObserver : MonoBehaviour {

	public int MAX_PARTICLES = 250;
	public int MIN_PARTICLES = 5;


	private const int MIN_INTENSIVITY_RANGE = 10;
	private const int MAX_INTENSIVITY = 60;

	//Light range const
	private const float MAX_RANGE = 15f;
	private const float MIN_RANGE = 0.2f;
	private const float RANGE_STEP = 0.1f;

	//Speed const
	private const float MAX_SPEED = 5f;
	private const float SPEED_SETEP = 0.001f;
	private const float MIN_SPEED = 0.2f;

	private GameObject emitter;

	void Start () {
		emitter = GameObject.Find ("Emitter");
	}

	void FixedUpdate () {
		ParticleEmitter emitterState = emitter.GetComponent<ParticleEmitter> ();
		handleEmission(emitterState);
		handleIntensivity (emitterState);
		handleRadius (emitterState);
		handleSpeed (emitterState);
		handleColor (emitterState);


	}


	private void handleEmission(ParticleEmitter emission){
		int particles = emission.particles;
		if(Input.GetKey(KeyCode.UpArrow))
			emission.particles = (particles < MAX_PARTICLES) ? particles+=1 : MAX_PARTICLES;
		if (Input.GetKey (KeyCode.DownArrow)) 
			emission.particles = (particles > MIN_PARTICLES) ? particles-=1 : MIN_PARTICLES;
	}

	private void handleIntensivity(ParticleEmitter emitterState){
		int top = emitterState.topIntensivity;
		int bottom = emitterState.bottomIntensivity;
		int delta = top - bottom;
		if (Input.GetKey (KeyCode.RightArrow)) 
			emitterState.topIntensivity = (top < MAX_INTENSIVITY) ? top += 1 : top;
		if (Input.GetKey (KeyCode.LeftArrow))
			emitterState.topIntensivity = (delta >= MIN_INTENSIVITY_RANGE) ? top -=1 : top; 
	}

	private void handleRadius(ParticleEmitter emitterState){
		float range = emitterState.particle.GetComponent<Light> ().range;
		bool inScope = range >= MIN_RANGE & range <= MAX_RANGE;
		if (Input.GetKey (KeyCode.Q))
			emitterState.particle.GetComponent<Light> ().range = range <= MAX_RANGE ? range+=RANGE_STEP : range; 
		if (Input.GetKey (KeyCode.W))
			emitterState.particle.GetComponent<Light> ().range = range >= MIN_RANGE ? range -= RANGE_STEP : range; 
	}

	private void handleSpeed(ParticleEmitter emitterState){
		float speed = emitterState.particle.GetComponent<ParticleBehaviour> ().delta;
		if(Input.GetKey(KeyCode.S))
			emitterState.particle.GetComponent<ParticleBehaviour> ().delta = speed > MIN_SPEED ? speed -= RANGE_STEP : speed;
		if (Input.GetKeyDown (KeyCode.A))
			emitterState.particle.GetComponent<ParticleBehaviour> ().delta = speed < MAX_SPEED ? speed += RANGE_STEP : speed;
	}

	private void handleColor(ParticleEmitter emitterState){
		
		Color color = emitterState.particle.GetComponent<Light> ().color;
		if (Input.GetKey (KeyCode.R)) 
			color.r = increase(color.r);
		if (Input.GetKey (KeyCode.F))
			color.r = decrease (color.r);
		if (Input.GetKey (KeyCode.T)) 
			color.g = increase(color.g);
		if (Input.GetKey (KeyCode.G))
			color.g = decrease (color.g);
		if (Input.GetKey (KeyCode.Y)) 
			color.b = increase(color.b);
		if (Input.GetKey (KeyCode.H))
			color.b = decrease (color.b);
		
		emitterState.particle.GetComponent<Light> ().color = color;
	}

	private float increase(float channel){
		return channel < 1f ? channel += 0.01f : channel;
	}


	private float decrease(float channel){
		return channel > 0f ? channel -= 0.01f : channel;
	}
}
