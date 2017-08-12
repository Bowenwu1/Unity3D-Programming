using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSActionManager : MonoBehaviour {
	private Dictionary<int, SSAction> actions = new Dictionary<int, SSAction> ();
	private List<SSAction> waitingAdd = new List<SSAction>();
	private List<int> waitingDelete = new List<int>();

	protected void Update() {
		foreach (SSAction ac in waitingAdd)
		{
			actions[ac.GetInstanceID()] = ac;
		}
		waitingAdd.Clear();

		foreach (KeyValuePair<int, SSAction> kv in actions) {
			SSAction ac = kv.Value;
			if (ac.destory) {
				waitingDelete.Add(ac.GetInstanceID());
			} else if (ac.enable) {
				ac.Update();
			}
		}

		foreach(int key in waitingDelete) {
			SSAction ac = actions[key];
			actions.Remove(key);
			DestroyObject(ac);
		}
		waitingDelete.Clear();
	}

	public void RunAction(GameObject gameobject, SSAction action, ISSActionCallback manager) {
		action.gameobject = gameobject;
		// just let it move relative to their father
		action.transform = gameobject.transform;
		action.callback = manager;
		/* !!!!!!!!!!!!!!!!!!!!!!!!!!
		 * bug happen here --20170320 2306
		 * if this action is used twice, we need to reset
		 * action.destory and action.enable
		 * But this is not a good convention
		 * -- by BowenWu
		 */
		action.destory = false;
		action.enable = true;
		waitingAdd.Add(action);
		action.Start();
	}

	protected void Start() {}
}