using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCActionManager :  SSActionManager, IActionManager, ISSActionCallback{

	protected new void Start() {
	}

	protected new void Update() {
		base.Update ();
	}

	public void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Competeted,
		int intParam = 0, string strParam = null, Object objectParam = null) {
	}
		
	public void emitDisk (GameObject[] disks, int speed) {
		foreach (GameObject g in disks) {
			this.RunAction (g, CCEmitDiskAction.GetSSAction (new Vector3 (0,
				Random.Range (0.5f, 1) * 10, Random.Range (0.5f, 1) * 10)), this);
		}
	}
}
