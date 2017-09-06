using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	void Update () {
		if(Input.GetKeyUp(KeyCode.Space))
		{
			Application.LoadLevel(1);
		}
	}
}