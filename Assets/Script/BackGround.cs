using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour {

	public float speed;
	public int numBGPanels = 6;

	void Start() {
		
	}

	void Update() {
		transform.Translate (Vector3.left * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.name == "BackgroundLoop") {			
			float widthOfBGObject = ((BoxCollider2D)GetComponent<Collider2D>()).size.x - 0.01f;
			Vector3 pos = this.transform.position;
			pos.x += widthOfBGObject* numBGPanels;
			this.transform.position = pos;	
		}
	}

}
