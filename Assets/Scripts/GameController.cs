using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static float EnemySpawn_xMin = 50f;
	public static float EnemySpawn_xMax = 60f;
	public static float EnemySpawn_yMin = 0f;
	public static float EnemySpawn_yMax = 16f;
	public static float EnemySpawn_zMin = 5f;
	public static float EnemySpawn_zMax = 25f;



	public GameObject[] enemyList;
	public int enemySpawnCount = 7;
	public float spawnWait = 0.5f;
	public float startWait = 3.0f;
	public float waveWait = 1f;
	//public Text scoreText;
	//public Text gameOverText;
	//public Text restartText;
	public int spawnIncrease = 3;

	private int score = 0;
	private int oldScore;
	private bool gameOver;
	private bool readyForRestart;

	void Start(){
		oldScore = score;
		//gameOverText.text = "";
		//restartText.text = "";
		gameOver = false;
		readyForRestart = false;
		updateScore ();
		StartCoroutine(SpawnWaves());	
	}

	void Update(){
		if(gameOver){
			
		}
		if(readyForRestart){
			if(Input.anyKeyDown){
				SceneManager.LoadScene ("start");
			}
		}
	}

	//Spawn Enemy ships after a delay
	IEnumerator SpawnWaves(){
		//gameOverText.text = "READY?";
		yield return new WaitForSeconds (startWait);
		//gameOverText.text = "";
		while (!gameOver) {	
			for (int i = 0; i <= enemySpawnCount; i++) {
				int randomizer = Random.Range (0, enemyList.Length);
				//Alternate enemy spawn points between left and right
				Vector3 spawnPosition = new Vector3 (Random.Range (EnemySpawn_xMin, EnemySpawn_xMax), 
					Random.Range (EnemySpawn_yMin, EnemySpawn_yMax), 
					i % 2 == 0 ? Random.Range (EnemySpawn_zMin, EnemySpawn_zMax) : -1*Random.Range (EnemySpawn_zMin, EnemySpawn_zMax));
				Quaternion spawnRotation = Quaternion.identity;
				 Instantiate (enemyList[randomizer], spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			enemySpawnCount += spawnIncrease;
			yield return new WaitForSeconds (waveWait);
		}
	}

	void updateScore(){
		//scoreText.text = score.ToString();
	}

	public void addScoreValue(int newScoreValue){
		score += newScoreValue;
		print ("Score: " + score);
		updateScore ();
	}

	public void playerDied(){
		StopAllCoroutines();
		gameOver = true;
		//gameOverText.text = "Game Over";
		//scoreText.text = "";

		StartCoroutine (RestartCycle ());
	}

	IEnumerator RestartCycle(){
		yield return new WaitForSeconds (1.0f);
		if(score <= oldScore){
			//gameOverText.text = "Your Score\n"+ score;
		}else{
			//gameOverText.text = "New\nHigh\nscore!\n"+ score;
		}

		//restartText.text = "Restart?\n Press Any Key";
		readyForRestart = true;
	}
}
