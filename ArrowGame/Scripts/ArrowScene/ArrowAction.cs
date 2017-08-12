using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ArrowAction {
	/**
	 * @param arrow: arrow you are ready to shoot
	 * @param direction: direction of the arrow
	 * @param speed: the initial speed of the arrow
	 */
	void shootArrow (GameObject arrow, Vector3 direction, float speed = 5);

	/**
	 * To stop a arrow's movement
	 */
	void stopArrow(GameObject arrow);
}
