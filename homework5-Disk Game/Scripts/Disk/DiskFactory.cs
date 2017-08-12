using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskFactory : MonoBehaviour {
	public Object diskPrefab;

	private List<GameObject> used = new List<GameObject>();
	private List<GameObject> free = new List<GameObject> ();

	public int initDiskNum;
	void Start() {
		instantiateDisk ();
	}
	public GameObject getDisk() {
		if (free.Count < 1)
			instantiateDisk ();
		GameObject ret = free [0];
		free.RemoveAt (0);
		/**
		 * may need to extra work
		 */
		addToUsed (ret);
		ret.SetActive (true);
		return ret;
	}

	public void freeDisk(GameObject freeDisk) {
		/**
		 * I don't fully understand about predicate
		 * just try to use it in simple way
		 */
//		GameObject temp = used.Find (d => d == freeDisk);
		/**
		 * Do not find freeDisk in used List
		 */
		if (used.Remove (freeDisk)) {
			addToFree (freeDisk);			
		} else {
			return;
		}

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

	void instantiateDisk() {
		for (int i = 0; i < initDiskNum; ++i) {
			addToFree (Instantiate (diskPrefab) as GameObject);
		}
	}
}
