using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;
	public static string highScoreSlug = "HighScoreForLevel";

	public int currentLevel = 1;
	public int levelCount = 10;

	private bool singleLevelPlay = false;
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

	public void startGame(int? level = null) {
		if (level.Equals(null)) {
			singleLevelPlay = true;
		} else {
			singleLevelPlay = false;
		}

		SceneManager.LoadScene (levels [level ?? currentLevel]);
	}

	public int incrementLevel() {
		if (singleLevelPlay) {
			SceneManager.LoadScene ("StartMenu");
			return 0;
		} else {
			int nextLevel = (currentLevel += 1);
			SceneManager.LoadScene(levels[nextLevel]);
			return nextLevel;
		}
	}

	public void reloadLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void exit() {
		SceneManager.LoadScene ("StartMenu");
	}

	void generateLevels() {
		for (int i = 1; i <= levelCount; i++) {
			levels.Add (i, "Level" + i.ToString());
		}
	}
}