using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlePosition {
	public float radius = 0f;
	public float angle = 0f;
	public float time = 0f;
	public bool clockwise = true;

	private bool whetherIncreaseRadius = true;
	public particlePosition(float radius, float angle, float time) {
		this.radius = radius;
		this.angle = angle;
		this.time = time;
	}

	public void randomlyChangeRadius() {
		if (whetherIncreaseRadius) {
			this.radius += 0.3f;
			whetherIncreaseRadius = false;
		} else {
			this.radius -= 0.3f;
			whetherIncreaseRadius = true;
		}
	}

	public void Update() {
		if (clockwise)
			angle += 0.1f;
		else
			angle -= 0.1f;
		randomlyChangeRadius ();
	}

	public Vector3 getPosition() {
		float theta = angle / 180 * Mathf.PI;
		return new Vector3 (radius * Mathf.Cos (theta), 0f, radius * Mathf.Sin (theta));
	}
}
