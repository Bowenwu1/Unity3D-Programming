using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCSequenceAction : SSAction, ISSActionCallback {
    public List<SSAction> sequence;
    public int repeat = -1;
    public int start = 0;

    public static CCSequenceAction GetSSAction(int repeat, int start, List<SSAction> sequence) {
        CCSequenceAction action = ScriptableObject.CreateInstance<CCSequenceAction>();
        action.repeat = repeat;
        action.sequence = sequence;
        action.start = start;
        return action;
    }

    public override void Update() {
		/*if (sequence.Count == 0) return;
        if (start < sequence.Count) {
            sequence[start].Update();
        }*/
		sequence [start].Update ();
    }

    public override void Start() {
		Debug.Log ("on CCSequenceActionStart");
		// Debug.Log (this.transform.parent);
        foreach (SSAction action in sequence)
        {
            action.gameobject = this.gameobject;
			action.transform = this.transform;
            action.callback = this;
        }
		start = 0;
		sequence [0].Start ();
    }
    public void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Competeted,
                int intParam = 0, string strParam = null, Object objectParam = null) {
                    source.destory = false;
                    this.start++;
         if (this.start >= sequence.Count) {
                        this.start = 0;
                        if (repeat > 0) repeat--;
                        if (repeat == 0) {
                            this.destory = true;
                            this.callback.SSActionEvent(this);
                        }
		} else {
			sequence [start].Start ();
		}
    }
}