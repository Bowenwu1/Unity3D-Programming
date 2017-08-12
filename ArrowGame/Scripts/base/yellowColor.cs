using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Renderer> ().material.color = Color.yellow;	
	}
}
