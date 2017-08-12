using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsActionManager : MonoBehaviour, IActionManager{
	public void emitDisk(GameObject[] disks, int speed) {
		foreach (GameObject g in disks) {
			/** give a initial spped to disk
			 *  so that the disks cound fly
			 */
			g.GetComponent<Rigidbody> ().velocity = new Vector3 (0,
				Random.Range (0.5f, 1) * 10, Random.Range (0.5f, 1) * 10);
		}
	}
}
