using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionManager {
	/**
	 * emitDisk according to the paramter
	 * @param disks: the instances of disks you are ready to emit
	 * @param speed: the initial speed for disks
	 * @param c    : the color of disks you emit
	 */
	 void emitDisk(GameObject[] disks, int speed);
}
