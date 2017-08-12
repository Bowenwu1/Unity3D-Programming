using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour
{
	/* 0 for no chess
	 * 1 for player1
	 * 2 for player2
	 */
	private int[,] state = new int[3, 3];
	/* switch turn
	 * 1 for player1
	 * 2 for player2
	 */
	private int turn = 1;
	private bool whetherEnd = false;
	private bool whetherEqual = false;
	private int xMove = 350;
	private int yMove = 150;
	// Use this for initialization
	void Start ()
	{
		init ();
		Camera view = GetComponent<Camera> ();
		view.backgroundColor = Color.white;
	}

	void OnGUI ()
	{
		GUI.backgroundColor = Color.white;
		// reset button
		if (GUI.Button (new Rect (25 + xMove, 250 + yMove, 100, 50), "Restart")) {
			init ();
			return;
		}
		// draw the chess table on each frame
		for (int i = 0; i < 3; ++i)
			for (int j = 0; j < 3; ++j) {
				switch (state [i, j]) {
				case 0:
					if (GUI.Button (new Rect (i * 50 + xMove, j * 50 + yMove, 50, 50), ""))
						click (i, j);
					break;
				case 1:
					if (GUI.Button (new Rect (i * 50 + xMove, j * 50 + yMove, 50, 50), "O"))
						click (i, j);
					break;
				case 2:
					if (GUI.Button (new Rect (i * 50 + xMove, j * 50 + yMove, 50, 50), "X"))
						click (i, j);
					break;
				default:
					break;
				}
			}
		GUI.color = Color.black;
		if (whetherEqual) {
			GUI.Label (new Rect (xMove, 170 + yMove, 200, 100), "No winner here, press Restart!");
		}
		else if (whetherEnd) {
			char winner = (turn == 2) ? 'O' : 'X';
			GUI.Label (new Rect (xMove, 170 + yMove, 200, 100), winner + " win! press restart to start over");
		}
		
	}

	void click (int x, int y)
	{
		if (state [x, y] == 0 && !whetherEnd) {
			state [x, y] = turn;
			checkWhetherWin (x, y);
			turn = (turn == 2) ? 1 : 2;
		}
	}

	void checkWhetherWin (int x, int y)
	{
		// horizontal
		if (state [x, 0] == state [x, 1] && state [x, 1] == state [x, 2]) {
			whetherEnd = true;
			Debug.Log ("win at horizontal");
		}
		// vertical
		if (state [0, y] == state [1, y] && state [1, y] == state [2, y]) {
			whetherEnd = true;
			Debug.Log ("win at vertical");
		}
		// diagonal
		bool flag = true;
		for (int i = 0; i < 3; ++i) {
			if (state [i, i] != state [x, y])
				flag = false;
		}
		if (flag == true) {
			whetherEnd = true;
			Debug.Log ("win at diagonal 1");
		}
		flag = true;
		for (int i = 2; i > -1; --i) {
			if (state [2 - i, i] != state [x, y])
				flag = false;
		}
		if (flag == true) {
			whetherEnd = true;
			Debug.Log ("win at diagonal 2");
		}
		flag = true;
		for (int i = 0; i < 3; ++i)
			for (int j = 0; j < 3; ++j) {
				if (state [i, j] == 0)
					flag = false;
			}
		if (flag) {
			whetherEnd = true;
			whetherEqual = true;
		}
	}
	// init all things when restart button pressed
	void init ()
	{
		Debug.Log ("chess start");
		for (int i = 0; i < 3; ++i)
			for (int j = 0; j < 3; ++j)
				state [i, j] = 0;
		whetherEnd = false;
		whetherEqual = false;
		turn = 1;
	}
}
