using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public float paddleSpeed = 1f;
	
	private Vector3 paddlePos = new Vector3 (0, -9.5f, 0);

	// Update is called once per frame
	void Update () {
		float xpaddlePos = transform.position.x + Input.GetAxis("Horizontal") * paddleSpeed;
		paddlePos = new Vector3 (Mathf.Clamp (xpaddlePos, -8.1f, 8.1f), -9.5f, 0);
		gameObject.transform.position = paddlePos;
	}
}
