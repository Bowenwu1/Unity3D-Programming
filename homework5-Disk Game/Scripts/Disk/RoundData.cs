using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundData : MonoBehaviour {
	private ScoreRecorder SR;

	private struct data {
		public int num;
		public int speed;
		public Color color;
		public data(int n, int s, Color c) {
			num = n;
			speed = s;
			color = c;
		}
	}

	private List<data> storage;
	void Start() {
		SR = Singleton<ScoreRecorder>.Instance;
		storage = new List<data> ();
		storage.Add (new data (1, 10, Color.blue));
		storage.Add (new data (2, 10, Color.green));
	}

	public int getNextRoundNum() {
		int round = SR.getRound () % 2;
		return storage [round].num;
	}

	public int getNextRoundSpeed() {
		int round = SR.getRound () % 2;
		return storage [round].speed;
	}

	public Color getNextRoundColor() {
		int round = SR.getRound () % 2;
		return storage [round].color;
	}
}
