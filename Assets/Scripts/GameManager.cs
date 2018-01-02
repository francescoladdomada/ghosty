using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public PlayerData playerSavedData;

	public int inGameScore;
	public int inGameCoins;
	public int inGameLevel;

	public bool isGameOver = true;

	void Start () {
		ResetInGameData ();
		playerSavedData = Persistency.Load ();
	}
		
	public void GoToTitleScren() {
		ResetInGameData ();
		SceneManager.LoadScene("Scenes/Title");
		isGameOver = true;
	}

	public void LoadNextLevel() {
		inGameLevel += 1;
		if (inGameLevel > 4)
			inGameLevel = 4;
		Invoke ("LoadLevel", 1f);
	}

	public void LoadLevel() {
		SceneManager.LoadScene("Scenes/Levels/" + inGameLevel);
		if (inGameLevel == 1) {
			GetComponent<Timer> ().RestartTimer ();
			inGameScore = 0;
		}
		else if(inGameLevel > 1) {
			GetComponent<Timer> ().AddTime ();
		}
	}

	public void StartGame() {
		ResetInGameData ();
		LoadLevel ();
		isGameOver = false;
	}


	public void UpdateSavedData() {
		
		if (inGameScore > playerSavedData.bestScore)
			playerSavedData.bestScore = inGameScore;

		playerSavedData.coins += inGameCoins;

		if (inGameLevel > playerSavedData.levelReached)
			playerSavedData.levelReached = inGameLevel;
		
		Persistency.Save (playerSavedData);

		// ResetInGameData ();

	}

	public void DeleteGameData() {
		Persistency.Delete ();
		playerSavedData = new PlayerData ();
	}

	public void ResetInGameData() {
		inGameScore = 0;
		inGameCoins = 0;
		inGameLevel = 0;
	}
	
	void Update () {

	}


}
