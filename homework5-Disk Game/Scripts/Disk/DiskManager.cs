using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskManager : MonoBehaviour {

	private List<GameObject> alreadyEmited;
	private DiskFactory DF;
	public ParticleSystem explosion;
	public Transform mainCamera;
	void Start() {
		alreadyEmited = new List<GameObject> ();
		explosion = Instantiate (explosion) as ParticleSystem;
		DF = Singleton<DiskFactory>.Instance;
	}

	void Update() {
		/**
		 * free those disk already
		 * fall into the ground
		 */
		List<GameObject> temp = new List<GameObject> ();
		temp = alreadyEmited.FindAll (d => d.transform.position.y < 0);
		foreach(GameObject item in temp) {
			if (item.transform.position.y < 0) {
				DF.freeDisk (item);
				alreadyEmited.Remove (item);
			}
		}
	}

	public void emitDisk(int diskNumer, Color c, int speed) {
		for (int i = 0; i < diskNumer; ++i) {
			GameObject temp = DF.getDisk ();
			temp.transform.position = mainCamera.transform.position;
			temp.GetComponent<Rigidbody> ().velocity = new Vector3 (0,
				Random.Range (0.5f, 1) * 10, Random.Range (0.5f, 1) * 10);
			temp.GetComponent<Renderer> ().material.color = c;
			alreadyEmited.Add (temp);
		}
	}

	public void shutDisk(GameObject shutedDisk) {
		/**
		 * play explosion effect
		 */
		explosion.transform.position = shutedDisk.transform.position;
		explosion.Play ();

		/**
		 * free the disk
		 */
		if (alreadyEmited.Find(d => d == shutedDisk) == null) {
			/* error happen */
			Debug.Log ("This Disk is not emitted by DiskManager");
		} else {
			/* normal case */
			alreadyEmited.Remove (shutedDisk);
			DF.freeDisk (shutedDisk);
			explosion.GetComponent<Renderer> ().material.color = getObjectColor (shutedDisk);
			explosion.transform.position = shutedDisk.transform.position;
			explosion.Play ();
		}
	}

	public bool whetherNextRound() {
		return alreadyEmited.Count == 0;
	}
	private Color getObjectColor(GameObject temp) {
		return temp.GetComponent<Renderer> ().material.color;
	}
}
