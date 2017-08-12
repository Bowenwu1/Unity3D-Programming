using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEvent : MonoBehaviour {

	private ArrowSceneController ASC;
	// Use this for initialization
	void Start () {
		ASC = Singleton<ArrowSceneController>.Instance;
	}

	void OnTriggerEnter(Collider c) {
		this.gameObject.SetActive (false);
		ASC.onTarget (c.gameObject.layer, this.gameObject);
	}

}
