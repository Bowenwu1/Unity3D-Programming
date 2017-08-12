using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCEmitDiskAction : SSAction {
	private Vector3 speed;
	public void Start() {
		// nothing to do
	}

	public void Update() {
		// change the spped of y-direction
		speed.y -= 9.8f * Time.deltaTime;
		// change the location of object as speed
		transform.position += speed * Time.deltaTime;

		// judge when to stop
		if (transform.position.y < 0) {
			this.destory = true;
		}
	}

	public static CCEmitDiskAction GetSSAction(Vector3 speed) {
		CCEmitDiskAction action = ScriptableObject.CreateInstance<CCEmitDiskAction> ();
		action.speed = speed;
		return action;
	}
}
