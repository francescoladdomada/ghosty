using UnityEngine;
using UnityEngine.SceneManagement;

public class DDOL : MonoBehaviour {

	public void Awake() {
		DontDestroyOnLoad (gameObject);
	}

	void Start() {
		SceneManager.LoadScene("Scenes/Title");
	}
}
