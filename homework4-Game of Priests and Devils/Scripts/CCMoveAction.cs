using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCMoveAction : SSAction {
    // this kind of action move towards the Vector3
    // but not move to a target
    public Vector3 distance;
    private Vector3 target;
    public float speed;

    public static CCMoveAction GetSSAction(Vector3 distance, float speed) {
        CCMoveAction action = ScriptableObject.CreateInstance<CCMoveAction>();
        action.distance = distance;
        action.speed = speed;
        return action;
    }

    public override void Update() {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
        if (this.transform.position == target) {
            this.destory = true;
            this.callback.SSActionEvent(this);
        }
    }

    public override void Start() {
        target = this.transform.position + distance;
		Debug.Log ("on MoveAction Start!");
		Debug.Log ("target is :" + target);
    }
}