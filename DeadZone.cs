using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

	void OnTriggerEnter (Collider lose) {
		GM.instance.LoseLife();
	}
}
