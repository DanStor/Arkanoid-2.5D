using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public  class TextController : MonoBehaviour {

	public Text livesText;
	public Text wins;
	public int lives;
	public int winCount = 0;
	public static TextController instance = null;
	
	// Use this for initialization
	void Start () {
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
			
		lives = 3;
			
		DontDestroyOnLoad(this);

	}
	
	public void LivesUpdate () {
		lives--;
		Debug.Log (lives);
		livesText.text = "Lives: " + lives;
	}
	
	public void ScoreUpdate () {
		winCount++;
		wins.text = "Wins: " + winCount;
	}
}
