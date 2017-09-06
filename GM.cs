using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	public int lives = 3;
	public int bricks = 20;
	public int winCount = 0;
	public float resetDelay = 1f;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	public GameObject ballDeath;
	public static GM instance = null;
	public Text livesText;
	public Text wins;
	
	private Ball ball;
	private GameObject clonePaddle;
	
	void Awake () 
	{
		if (instance == null)
		{
			instance = this;
		}	
		else
		{
			Destroy (gameObject);
		}
		
		Setup();
	}

	public void Setup()
	{
		SetupPaddle();
		Instantiate(bricksPrefab, new Vector3 (transform.position.x, -2, transform.position.z), Quaternion.identity);
	}
	
	void GameCheck()
	{
		if (bricks < 1)
		{
			youWon.SetActive(true);
			winCount++;
			wins.text = "Wins: " + winCount;
			Time.timeScale = .25f;
			DestroyBall();
			Invoke ("Repeat", resetDelay);
		}
		
		if (lives < 1)
		{
			gameOver.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}
		
	}
	
	void Reset()
	{
		Time.timeScale = 1f;
		Application.LoadLevel(Application.loadedLevel);
	}
	
	
	void Repeat()
	{
		Time.timeScale = 1f;
		bricks = 20;
		FindBall();
		Instantiate(bricksPrefab, new Vector3 (transform.position.x, -2, transform.position.z), Quaternion.identity);
		Destroy(clonePaddle);
		SetupPaddle();
		youWon.SetActive(false);
	}
	
	public void LoseLife()
	{
		lives--;
		livesText.text = "Lives: " + lives;
		DestroyBall();
		Invoke ("SetupPaddle", resetDelay);
		DestroyPaddle();
		GameCheck();
	}
	
	void SetupPaddle()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
	}
	
	public void DestroyBrick()
	{
		bricks--;
		GameCheck();
	}
	
	void DestroyBall()
	{
		FindBall();
		Instantiate (ballDeath, ball.gameObject.transform.position, Quaternion.identity);
		Destroy (ball.gameObject);
	}
	
	void DestroyPaddle()
	{
		Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy(clonePaddle);
	}
	
	void FindBall() {
		ball = FindObjectOfType<Ball>();
	}
}
