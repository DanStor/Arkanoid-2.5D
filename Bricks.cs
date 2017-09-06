using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {
	
	public GameObject burstParticles;
	public GameObject bPClone;
	
	private GM gameManager;

	void OnCollisionExit (Collision pop)
	{
		bPClone = Instantiate(burstParticles, transform.position, Quaternion.identity) as GameObject;
		GM.instance.DestroyBrick();
		Destroy(gameObject);
	}
}