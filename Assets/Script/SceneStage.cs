using UnityEngine;
using System.Collections;

public class SceneStage : MonoBehaviour {
	enum StageScene {
		FIRST_PLAY,
		RUNNING,
		DEATH
	}
	public static bool wasPlay = false;
	public BirdMovement bird;
	private StageScene _stage;

	void Start () {
		if (!wasPlay) {
			ChangeState (StageScene.FIRST_PLAY);
		}

		wasPlay = true;
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && this._stage != StageScene.RUNNING) { 
			ChangeState(StageScene.RUNNING);
		}

		if (bird.dead && this._stage != StageScene.DEATH) {
			ChangeState(StageScene.DEATH);
		}

		if (_stage == StageScene.DEATH) {
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0) && this._stage != StageScene.RUNNING) {
				Time.timeScale = 1;
				Application.LoadLevel(Application.loadedLevel);
			}			
		}

	}

	void ChangeState(StageScene stage) {
		switch (stage) {
		case StageScene.FIRST_PLAY:
			Time.timeScale = 0;
			GetComponent<SpriteRenderer>().enabled = true;
			break;
		case StageScene.RUNNING:
			Time.timeScale = 1;
			GetComponent<SpriteRenderer>().enabled = false;
			break;
		case StageScene.DEATH:
			Time.timeScale = 0;
			GetComponent<SpriteRenderer>().enabled = true;
			break;
		}
		
		this._stage = stage;
	}
}
