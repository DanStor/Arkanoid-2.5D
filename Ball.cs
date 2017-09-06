using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float ballInitalVelocity = 20f;
	
	private Rigidbody rb;
	private bool ballInPlay = false;
	private Ball instance = null;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetButtonUp("Fire1") || Input.GetKeyUp(KeyCode.Space)) && !ballInPlay)
		{
			transform.parent = null;
			LaunchBall();
			ballInPlay = true;
		}
		if(instance == null)
		{
			instance = this;
		}
	}
	
	void LaunchBall() {
		rb.isKinematic = false;
		rb.velocity = new Vector3 (2f, ballInitalVelocity, 0);
	}
	
	void OnCollisionExit (Collision bounce) {
		rb.AddForce ((Random.Range (-0.5f, 0.5f)), 0, 0, ForceMode.VelocityChange);
	}
}
