using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;

	public int level = 1;
	private Dictionary<int, string> levels = new Dictionary<int, string>();

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
		initGame ();
	}

	void initGame() {
		generateLevels ();
	}

	public int incrementLevel() {
		int nextLevel = (level += 1);
		SceneManager.LoadScene(levels[nextLevel]);

		return nextLevel;
	}

	public void reloadLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	void generateLevels() {
		levels.Add (1, "Level1");
		levels.Add (2, "Level2");
		levels.Add (3, "Level4");
		levels.Add (4, "Level5");
	}
}