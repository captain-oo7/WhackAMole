using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject moleConntainer;
	public float spawnDuration = 1.5f;
	public float gameTimer = 15f;
	private float resetTimer = 3f;
	public Player player;
	public float spawnDecrement = 0.1f;
	public TextMesh infoText;
	public float minimumSpawnDuration = 0.5f;
	private float spawnTimer = 0f;
	private Mole[] moles; 
	// Use this for initialization
	void Start () {
		moles = moleConntainer.GetComponentsInChildren<Mole> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		gameTimer -= Time.deltaTime;
		if (gameTimer > 0f) {
			spawnTimer -= Time.deltaTime;
			if (spawnTimer <= 0f) {
				moles [Random.Range (0, moles.Length)].Rise ();

				spawnDuration -= spawnDecrement;
				if (spawnDuration < minimumSpawnDuration) {
					spawnDuration = minimumSpawnDuration;
				}

				spawnTimer = spawnDuration;
			}
			infoText.text = "Hit all the Moles\nTime:" + Mathf.Floor (gameTimer) + "\nScore:" + player.score;
		} else {
			infoText.text = "Game Over Your Score " + Mathf.Floor (player.score);
			resetTimer -= Time.deltaTime;
			if (resetTimer <= 0f) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			
			}
		}
	}
}
