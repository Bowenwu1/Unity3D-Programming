using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour {
	private ParticleSystem particleSys;
	private ParticleSystem.Particle[] particleArray;
	private particlePosition[] position;

	public int count = 10000;
	public float size = 0.03f;
	public float minRadius = 5.0f;
	public float maxRadius = 12.0f;
	void Start () {
		particleArray = new ParticleSystem.Particle[count];
		position = new particlePosition[count];

		particleSys = this.GetComponent<ParticleSystem> ();
		particleSys.startSpeed = 0;
		particleSys.startSize = size;
		particleSys.loop = true;
		particleSys.maxParticles = count;
		particleSys.Emit (count);
		particleSys.GetParticles (particleArray);

		randomlyPutParticle ();
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < count; ++i) {
			position [i].Update ();
			particleArray [i].position = position [i].getPosition ();
		}

		particleSys.SetParticles (particleArray, particleArray.Length);
	}

	private void randomlyPutParticle() {
		for (int i = 0; i < count; ++i) {
			float midRadius = (maxRadius + minRadius) / 2;
			float minRate = Random.Range (1.0f, midRadius / minRadius);
			float maxRate = Random.Range (midRadius / maxRadius, 1.0f);
			float radius = Random.Range (minRadius * minRate, maxRadius * maxRate);

			float angle = Random.Range (0f, 360f);
			float theta = angle / 180 * Mathf.PI;

			float time = Random.Range (0f, 360f);

			position [i] = new particlePosition (radius, angle, time);
			position [i].clockwise = (i % 2 == 0);

			particleArray [i].position = new Vector3 (position [i].radius * Mathf.Cos (theta), 0f,
				position [i].radius * Mathf.Sin (theta));
		}

		particleSys.SetParticles (particleArray, particleArray.Length);
	}
}
