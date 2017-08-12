using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class UserGUI : MonoBehaviour {
	IUserAction user;
	ScoreRecorder SR;
	// Use this for initialization
	void Start () {
		SR = Singleton<ScoreRecorder>.Instance;
		user = SSDirector.getInstance ().currentSceneController as IUserAction;
	}
	void OnGUI() {
		/** Round Text
		 * at the left-top
		 */
		string Round = "Round " + SR.getRound ();
		GUI.TextArea (new Rect (10, 10, 100, 20), Round);

		string Score = "Score : " + SR.getScore ();
		GUI.TextArea (new Rect (300, 10, 100, 20), Score);

		/* reset button */
		if (GUI.Button (new Rect (300, 300, 60, 30), "Reset")) {
			user.reset ();
		}
	}
}