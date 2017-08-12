using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRecorder : MonoBehaviour {

	private int score;
	void Start() {
		score = 0;
	}
	public void addScore(int p) {
		if (p <= 0) {
			throw new UnityException ("illegal argument. On addScore of ScoreRecorder");
		}

		score += p;
	}

	public int getScore() {
		return score;
	}
}
