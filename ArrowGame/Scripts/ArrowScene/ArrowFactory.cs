 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFactory : MonoBehaviour {

	public Object ArrowPrefab;

	private List<GameObject> used = new List<GameObject>();
	private List<GameObject> free = new List<GameObject>();
	// Use this for initialization
	void Start () {
		instantiate ();
	}

	void addToFree(GameObject param) {
		/**
		 * Need to do some init work here
		 */
		param.SetActive (false);
		free.Add (param);
	}

	void addToUsed(GameObject param) {
		/**
		 * may need some other work here
		 */
		used.Add (param);
	}

	void instantiate() {
		for (int i = 0; i < 10; ++i) {
			addToFree (Instantiate (ArrowPrefab) as GameObject);
		}
	}

	// public method
	public GameObject get() {
		if (free.Count < 1) {
			instantiate ();
		}

		GameObject ret = free [0];
		free.RemoveAt (0);
		addToUsed (ret);
		ret.SetActive (true);
		return ret;
	}

	public void release(GameObject f) {
		if (f == null) {
			throw new UnityException ("Null argument of releasing GameObject");
		}

		if (used.Find(d => d == f) == null) {
			throw new UnityException ("This GameObject is not come from this Factory!");
		}
		used.Remove (f);
		addToFree (f);
	}
}
