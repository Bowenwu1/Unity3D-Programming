using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhyciscActionManager : MonoBehaviour, ArrowAction {
	public void shootArrow (GameObject arrow, Vector3 direction, float speed = 5) {
		arrow.SetActive (true);
		arrow.GetComponent<Rigidbody> ().velocity = direction * speed;
	}

	public void stopArrow(GameObject arrow) {
		arrow.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
		arrow.GetComponent<Collider> ().enabled = false;
	}

}
