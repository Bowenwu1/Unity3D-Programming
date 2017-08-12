using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundContrller : MonoBehaviour, ISceneController, IUserAction {

	private DiskManager DM;
	private ScoreRecorder SR;
	private RoundData RD;
	private GameObject presentDisk;
	public Transform mainCamera;
	// Use this for initialization
	void Awake () {
		Debug.Log ("Start");
		SSDirector.getInstance ().currentSceneController = this;
		DM = Singleton<DiskManager>.Instance;
		SR = Singleton<ScoreRecorder>.Instance;
		RD = Singleton<RoundData>.Instance;
	}
	// Update is called once per frame
	void Update () {
		if (DM.whetherNextRound()) {
			DM.emitDisk (RD.getNextRoundNum(), RD.getNextRoundColor(), RD.getNextRoundSpeed());
			SR.nextRound ();
			return;
		}
		if (Input.GetMouseButtonDown(0)) {
			Vector3 mp = Input.mousePosition;

			Camera ca = mainCamera.GetComponent<Camera> ();
			Ray ray = ca.ScreenPointToRay (Input.mousePosition);

			RaycastHit hit;

			if (Physics.Raycast(ray, out hit)) {
				if (hit.collider.gameObject.tag == "Disk") {
					DM.shutDisk (hit.collider.gameObject);
					SR.hitOne ();
				}
			}
		}
	}

	public void LoadResources() {}

	public void reset() {
		Application.LoadLevel(Application.loadedLevelName);
	}
}
