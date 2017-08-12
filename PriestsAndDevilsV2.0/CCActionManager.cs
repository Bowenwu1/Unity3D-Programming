using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCActionManager : SSActionManager, ISSActionCallback {
    public CCMoveToAction boat_to_end, boat_to_begin;
    // simple moves used to make a sequence move
    public CCMoveAction move_up, move_down;
    public CCMoveToAction move_to_boat_left_begin, move_to_boat_right_begin;
	public CCMoveToAction move_to_boat_left_end, move_to_boat_right_end;

    public CCSequenceAction get_on_boat_left_begin, get_on_boat_right_begin;
	public CCSequenceAction get_on_boat_left_end, get_on_boat_right_end;
    // public CCSequenceAction get_off_boat;

    private float object_speed;
    private float boat_speed;
    public GenGameObjects sceneController;
    protected new void Start() {
        object_speed = 4.0f;
        boat_speed = 4.0f;
		sceneController = (GenGameObjects)SSDirector.getInstance().currentSceneController;
        sceneController.actionManager = this;
        
        move_up = CCMoveAction.GetSSAction(new Vector3(0, 1, 0), object_speed);
        move_down = CCMoveAction.GetSSAction(new Vector3(0, -1, 0), object_speed);

        move_to_boat_left_begin = CCMoveToAction.GetSSAction(new Vector3(-2.3f, 2, 0), object_speed);
        move_to_boat_right_begin = CCMoveToAction.GetSSAction(new Vector3(-1.2f, 2, 0), object_speed);
        
		move_to_boat_left_end = CCMoveToAction.GetSSAction (new Vector3 (0.7f, 2, 0), object_speed);
		move_to_boat_right_end = CCMoveToAction.GetSSAction (new Vector3 (1.8f, 2, 0), object_speed);

		get_on_boat_left_begin = CCSequenceAction.GetSSAction(0, 0, new List<SSAction> {
			move_up, move_to_boat_left_begin, move_down
		});
        get_on_boat_right_begin = CCSequenceAction.GetSSAction(0, 0, new List<SSAction> {
			move_up, move_to_boat_right_begin, move_down
		});

		get_on_boat_left_end = CCSequenceAction.GetSSAction (0, 0, new List<SSAction> {
			move_up,
			move_to_boat_left_end,
			move_down
		});
		get_on_boat_right_end = CCSequenceAction.GetSSAction (0, 0, new List<SSAction> {
			move_up,
			move_to_boat_right_end,
			move_down
		});

		boat_to_end = CCMoveToAction.GetSSAction (new Vector3 (1.7f, 0, 0), boat_speed);
		boat_to_begin = CCMoveToAction.GetSSAction (new Vector3 (-1.7f, 0, 0), boat_speed);
        
    }

    protected new void Update() {
        base.Update();
    }

    public void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Competeted,
                        int intParam = 0, string strParam = null, Object objectParam = null) {
		Debug.Log ("change back Game_state");
        sceneController.game_state = GenGameObjects.State.normal;
        // sceneController.game_state = sceneController.State.moving;
    }
}