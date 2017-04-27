using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	public bool dead;

	public float jumpVelocity;
	public float g = -7.8f;

	private SpriteRenderer _spriteRender;

	private Animator _animator;

	void Start () {
		_animator = transform.GetComponentInChildren<Animator>();
	}


	void Update() {
		if (dead) {
			return;
		}

		// x = x0 + v0 * t + a * t * t / 2
		transform.position += Vector3.up * (jumpVelocity * Time.deltaTime + g * Time.deltaTime * Time.deltaTime / 2);
		
		// vt = v0 + a * t
		jumpVelocity += g * Time.deltaTime;
	
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			_animator.SetTrigger("DoFlap");
			jumpVelocity = 2.5f;		
		}

		if (jumpVelocity > 0) {
			float angle = Mathf.Lerp (0, 20, (jumpVelocity / 3) );
			transform.rotation = Quaternion.Euler(0, 0, angle);
		} else {
			float angle = Mathf.Lerp (0, -90, (-jumpVelocity / 6f) );
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		_animator.SetTrigger("Death");
		dead = true;
	}

}
