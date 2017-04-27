using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour {

	public float speed;
	public int numBGPanels = 6;

	private float _pipeMax;
	private float _pipeMin;

	private float _distanceOfThePipe;


	void Start() {
		//the min/max pipe can random
		this._pipeMax = -1f;
		this._pipeMin = -1.65f;

		//set speed of the pipe
		this.speed = .5f;

		//set distance between two pipe
		_distanceOfThePipe = 1.43f;	

		//random the height of the pipe in first time
		Vector3 pos = transform.position;
		pos.y = Random.Range(_pipeMin, _pipeMax);
		transform.position = pos;
	}

	void Update(){
		transform.Translate (Vector3.left * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.name == "BGLooper") {
			Vector3 pos = this.transform.position;
			pos.x += _distanceOfThePipe * numBGPanels;
			pos.y = Random.Range(_pipeMin, _pipeMax);
			transform.position = pos;
		}
	}
}
