using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRecorder : MonoBehaviour {
	private int round;
	private int score;

	public void hitOne() {
		score += 10;
	}

	public int getScore() {
		return score;
	}

	public void nextRound() {
		++round;
	}

	public int getRound() {
		return round;
	}
}
