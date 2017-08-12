using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSceneController : MonoBehaviour, ISceneController, IUserAction {

	public Transform mainCamera;
	public int maxScore;
	private bool whetherShoot;
	private ArrowFactory AF;
	private ScoreRecorder SR;
	private ArrowAction PAM;

	private GameObject target;
	private GameObject arrowOnTarget;
	private GameObject holding;
	void Awake () {
		whetherShoot = false;
		arrowOnTarget = null;
		SSDirector.getInstance ().currentSceneController = this;
		SSDirector.getInstance ().currentSceneController.LoadResources ();
		placeTarget ();
		PAM = Singleton<PhyciscActionManager>.Instance as ArrowAction;
		AF = Singleton<ArrowFactory>.Instance;
		SR = Singleton<ScoreRecorder>.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		// already shoot
		if (whetherShoot) {
			// when the arrow already out of the area
			if (arrowOnTarget.transform.position.y < -10) {
				AF.release (arrowOnTarget);
				whetherShoot = false;
				arrowOnTarget = null;
			}
		}
		// not shoot yet
		else {
			if (Input.GetMouseButtonDown(0)) {
				whetherShoot = true;
				Camera ca = mainCamera.GetComponent<Camera> ();
				Ray ray = ca.ScreenPointToRay (Input.mousePosition);
				arrowOnTarget = AF.get ();
				arrowOnTarget.transform.LookAt (Input.mousePosition);
				PAM.shootArrow (arrowOnTarget, ray.direction, 100f);
			}
		}
	}

	public void onTarget(int point, GameObject g) {
		PAM.stopArrow (g);
		whetherShoot = false;
		holding = AF.get ();
		SR.addScore (point);
	}
	public void LoadResources () {
		target = Resources.Load ("Prefabs/target") as GameObject;
		Debug.Log ("already Load resources");
	}

	private void placeTarget() {
		Debug.Log ("placing target");
		Debug.Log (target);
		Vector3 center = new Vector3 (0, 1, 0);
		Vector3 scale = new Vector3 (1, 0.1f, 1);
		for (int i = 1; i <= maxScore; ++i) {
			GameObject temp = Instantiate (target) as GameObject;
			temp.transform.position = center + Vector3.forward * i * 0.2f;
			temp.transform.localScale = scale * i;

			temp.layer = maxScore - i + 1;
			temp.SetActive (true);
			if (i % 2 == 1) {
				temp.GetComponent<Renderer> ().material.color = Color.red;
			} else {
				temp.GetComponent<Renderer> ().material.color = Color.white;
			}
		}
	}

	public int getScore() {
		return SR.getScore ();
	}
	public void reset() {}
}
