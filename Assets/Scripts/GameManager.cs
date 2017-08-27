using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;
	public static string highScoreSlug = "HighScoreForLevel";

	public int level = 1;
	public int levelCount = 9;
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

	public void startGame() {
		SceneManager.LoadScene (levels [level]);
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
		for (int i = 1; i <= levelCount; i++) {
			levels.Add (i, "Level" + i.ToString());
		}
	}
}