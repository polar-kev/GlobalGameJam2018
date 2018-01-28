﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public struct EnemySpawn{
	public const float xMin = 50f;
	public const float xMax = 60f;
	public const float yMin = 0f;
	public const float yMax = 16f;
	public const float zMin = 5f;
	public const float zMax = 25f;
}

public class GameController : MonoBehaviour {

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
				Vector3 spawnPosition = new Vector3 (Random.Range (EnemySpawn.xMin, EnemySpawn.xMax), 
					Random.Range (EnemySpawn.yMin, EnemySpawn.yMax), 
					i % 2 == 0 ? Random.Range (EnemySpawn.zMin, EnemySpawn.zMax) : -1*Random.Range (EnemySpawn.zMin, EnemySpawn.zMax));
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
