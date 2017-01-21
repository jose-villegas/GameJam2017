using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float BulletDuration;
	Rigidbody _rigidBody;

	// Use this for initialization
	void Start () {
		_rigidBody = gameObject.GetComponent<Rigidbody>();
	}

	public void Fire(Vector3 direction, float speed, float duration ){

	_rigidBody.velocity = direction * speed;
	BulletDuration = duration;
	Destroy(gameObject, BulletDuration);

	}
}