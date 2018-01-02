using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public bool			isStaticLevel = false;
	public int 			levelNumber;
	public int 			coinsToSpawnQuantity = 15;
	public int			coinsRandomRange = 5;
	public int[]		staticLevelBadPlatformIndexes;

	public int minRandomRangeForBadPlatforms = 3;
	public int maxRandomRangeForBadPlatforms = 7;

	public GameObject	_platformsPositions;
	public GameObject 	_pauseMenuCanvas;
	// public GameObject 	_gameOverMenuCanvas;

	public GameObject	_scoreText;
	public GameObject	_coinsText;

	private PlayerController 	pc;
	private GameManager 		gm;


	private bool	paused;
	private bool	gameStarted;
	private bool	levelCompleted = false;

	public int 	platformsLength;
	private GameObject platformsContainer;
	private GameObject[] 	platforms;


	// Use this for initialization
	void Start () {
		pc = Object.FindObjectOfType <PlayerController>();
		gm = Object.FindObjectOfType <GameManager> ();

		platformsContainer = new GameObject ();
		platformsContainer.transform.position = Vector3.zero;

		ResetLevel ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void CalculateLevelLength() {
		platformsLength = 0;
		foreach (Transform child in _platformsPositions.transform) {
			platformsLength++;
		}
	}

	public Platform GetPlatformByIndex(int index) {
		if( levelCompleted )
			index = platformsLength - 1;
		else if (index >= platformsLength) {
			index = platformsLength - 1;
			levelCompleted = true;
		}
		return platforms[index].GetComponent<Platform>();
	}



	private void CreateLevel() {
		DeleteAllChildren ();
		SetupPlatforms();

		SetupCoins ();

		InstantiatePlatforms ();
	}

	private void SetupPlatforms() {
		for (int i = 0; i < platformsLength; i++) {
			platforms [i] = new GameObject();
			platforms [i].AddComponent<Platform> ();
			platforms [i].GetComponent<Platform> ().index = i;
			platforms [i].GetComponent<Platform> ().type = 0;
			platforms [i].GetComponent<Platform> ().dealDamage = false;
			platforms [i].AddComponent<SpriteRenderer> ();
			platforms [i].GetComponent<SpriteRenderer> ().sortingLayerName = "Platforms";
		}

		if( isStaticLevel ) {
			foreach (int index in staticLevelBadPlatformIndexes) {
				if( index > 0)
					SetAsBadPlatform (platforms [index]);
			}
		}
		else {
			SetupBadPlatforms ();

			if (levelNumber == 2)
				SetupStandTrapPlatforms ();

			if (levelNumber == 3)
				SetupTimeTrapPlatforms ();

			if (levelNumber == 4) {
				SetupStandTrapPlatforms ();
				SetupTimeTrapPlatforms ();
			}
		}


		// set the last platform as the final ones
		platforms [platformsLength - 1].GetComponent<Platform> ().type = 2;
		platforms [platformsLength - 1].GetComponent<Platform> ().dealDamage = false;
	}

	private void SetupBadPlatforms() {
		int badPlatformSpawningIndex = 5;
		while (badPlatformSpawningIndex < platformsLength) {
			badPlatformSpawningIndex += Random.Range (minRandomRangeForBadPlatforms-1, maxRandomRangeForBadPlatforms);
			if (badPlatformSpawningIndex < platformsLength) {
				SetAsBadPlatform (platforms [badPlatformSpawningIndex]);
			}
		}
	}

	private void SetupStandTrapPlatforms() {
		int badPlatformSpawningIndex = 5;
		while (badPlatformSpawningIndex < platformsLength) {
			badPlatformSpawningIndex += Random.Range (7,18);
			if (badPlatformSpawningIndex < platformsLength) {
				platforms [badPlatformSpawningIndex].GetComponent<Platform> ().type = 3;
				platforms [badPlatformSpawningIndex].GetComponent<Platform> ().dealDamage = false;
			}
		}
	}

	private void SetupTimeTrapPlatforms() {
		int badPlatformSpawningIndex = 5;
		while (badPlatformSpawningIndex < platformsLength) {
			badPlatformSpawningIndex += Random.Range (6,18);
			if (badPlatformSpawningIndex < platformsLength) {
				platforms [badPlatformSpawningIndex].GetComponent<Platform> ().type = 4;
				platforms [badPlatformSpawningIndex].GetComponent<Platform> ().dealDamage = false;
			}
		}
	}

	private void SetAsBadPlatform(GameObject platform) {
		platform.GetComponent<Platform> ().type = 1;
		platform.GetComponent<Platform> ().dealDamage = true;
	}

	private void SetupCoins() {

		if (coinsToSpawnQuantity > 0) {
			int increaseOrDecrease;
			int shift;

			int coinsDistributionInterval = platformsLength / (coinsToSpawnQuantity + Random.Range(coinsRandomRange-1, coinsRandomRange) );
			int coinsDistributionIndex = coinsDistributionInterval - 1;

			while(coinsDistributionIndex < platformsLength - 1) {
				coinsDistributionIndex += coinsDistributionInterval + Random.Range(-2, 2);

				if (coinsDistributionIndex < platformsLength - 1) {
					// shift coins left or right if they are spawned on a bad platform
					if (platforms [coinsDistributionIndex].GetComponent<Platform> ().type == 1) {
						increaseOrDecrease = Random.Range (-1, 1);
						shift = -1;
						if (increaseOrDecrease == 1)
							shift = 1;
						coinsDistributionIndex += shift;
					}
				}


				if (coinsDistributionIndex < platformsLength - 1) {
					platforms [coinsDistributionIndex].GetComponent<Platform> ().hasCoin = true;

				}
			}
		}

	}

	private void DeleteAllChildren() {
		foreach (Transform child in platformsContainer.transform) {
			Destroy(child.gameObject);
		}
	}

	private void InstantiatePlatforms() {
		bool mirrored;
		Vector3 pos;
		for (int i = 0; i < platformsLength; i++) {
			pos = GameObject.Find ("PlatformsPositions/Platform (" + i + ")").transform.position;
			platforms [i].transform.position = pos;

			Sprite platformSprite = Resources.Load <Sprite> ("Sprites/Platforms/Platform_" + platforms [i].GetComponent<Platform> ().type);
	//		Sprite platformSprite = Resources.Load <Sprite> ("Sprites/Platforms/Platform_0" );

			if(platforms[i].GetComponent<Platform> ().type == 0) {
				float k = Random.Range (0.8f, 1f);
				platforms [i].GetComponent<SpriteRenderer> ().color = new Color (k, k, k, Random.Range(0.85f, 1f) );
			}
			if (platforms [i].GetComponent<Platform> ().type == 1) {
				Vector3 streetlampPosition = pos;
				streetlampPosition.x += 2f;
				GameObject streetlamp = (GameObject)Instantiate (Resources.Load ("Prefabs/Streetlamp"), pos, Quaternion.identity);
				streetlamp.transform.parent = platforms [i].transform;
				streetlamp.name = "Streetlamp";
			}

			if (platforms [i].GetComponent<Platform> ().type == 4) {
				Vector3 streetlampPosition = pos;
				streetlampPosition.x += 2f;
				GameObject streetlamp = (GameObject)Instantiate (Resources.Load ("Prefabs/StreetlampToggle"), pos, Quaternion.identity);
				streetlamp.transform.parent = platforms [i].transform;
				streetlamp.name = "StreetlampToggle";
			}
			mirrored = (Random.value > 0.5f);
			if( mirrored )
				platforms[i].transform.localScale = new Vector3(-1, 1, 1);

			platforms [i].GetComponent<SpriteRenderer> ().sprite = platformSprite;
			platforms [i].transform.parent = platformsContainer.transform;
			platforms [i].name = "Platform_" + i;

			if (platforms [i].GetComponent<Platform> ().hasCoin == true) {
				pos.y += 0.3f;
				GameObject coin = (GameObject)Instantiate (Resources.Load ("Prefabs/Coin"), pos, Quaternion.identity);
				coin.transform.parent = platforms [i].transform;
				coin.name = "Coin";
			}
		}
	}


	public bool IsGameRunning() {
		return !paused && !isGameOver() && gameStarted;
	}

	public bool isGameStarted() {
		return gameStarted;
	}

	public bool isGameOver() {
		return gm.isGameOver;
	}

	public bool IsPaused() {
		return paused;
	}

	public void PauseGame() {
		Time.timeScale = 0f;
		paused = true;
		_pauseMenuCanvas.GetComponent<CanvasMenu> ().ShowMenu ();
	}

	public void UnpauseGame() {
		Time.timeScale = 1f;
		paused = false;
		_pauseMenuCanvas.GetComponent<CanvasMenu> ().HideMenu ();
	}


	public void TogglePause() {
		if (paused)
			UnpauseGame ();
		else
			PauseGame();
	}

	public void HideMenus() {
		_pauseMenuCanvas.GetComponent<CanvasMenu> ().HideMenu ();
		// _gameOverMenuCanvas.GetComponent<CanvasMenu> ().HideMenu ();
	}

	public void ResetLevel() {
		gameStarted = true;
		HideMenus ();

		CalculateLevelLength ();
		platforms = new GameObject[platformsLength];

		CreateLevel ();
		pc.ResetPlayer ();
		// UpdateUITexts ();
		UnpauseGame ();
		UpdateUITexts ();
	}

	public void UpdateUITexts() {
		if( _scoreText.scene.IsValid() )
			_scoreText.GetComponent<UIText>().UpdateText ( gm.inGameScore + "" );

		if( _coinsText.scene.IsValid() )
			_coinsText.GetComponent<UIText>().UpdateText ( gm.inGameCoins + "" );
	}

	/*
	public void GameOver() {
		gameOver = true;
		_gameOverMenuCanvas.GetComponent<CanvasMenu> ().ShowMenu ();
		gm.UpdateSavedData ();
	}
	*/
}
