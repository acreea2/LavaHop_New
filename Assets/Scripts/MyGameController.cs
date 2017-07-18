using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyGameController : MonoBehaviour {
	public character character;
	public GameObject scoreDisplay;
	public GameObject levelDisplay;
	public int coinTotal;
	public static MyGameController instance = null;

	private GUIText levelDisplayText;
	private GUIText scoreDisplayText;
	private int currentLevel = 1;
	private Dictionary<int, string> levels = new Dictionary<int, string>();

	private GameObject exit;

	public void reloadLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void incrementLevel() {
		Debug.Log (currentLevel);
		currentLevel += 1;
		SceneManager.LoadScene(levels[currentLevel]);
		levelDisplayText.text = "Level: " + currentLevel;
		character.score = 0;
	}

	public void updateScoreDisplay() {
		scoreDisplayText.text = "Coins: " + character.score + "/" + coinTotal;
		Debug.Log("Log Score Display");
	}

	private void generateLevels() {
		levels.Add (1, "Level1");
		levels.Add (2, "Level2");
		levels.Add (3, "Level3");
		levels.Add (4, "Level4");
		levels.Add (5, "Level5");
		levels.Add (6, "JumpTest");
	}

	public void showExit() {
		exit.SetActive (true);
	}

//	void Awake() {
//		if (instance == null) {
//			instance = this;
//		} else if (instance != this) {
//			Destroy (gameObject);
//		}
//		Debug.Log(instance);
//		DontDestroyOnLoad (this);
//	}
//

	void Awake ()
	{
		DontDestroyOnLoad(this); //Ensures we don't lose our variables, playerPrefs work good for this too
	}

	// Use this for initialization
	void Start () {
		Debug.Log ("STARTED!!!@");
		scoreDisplayText = scoreDisplay.GetComponent<GUIText>();
		levelDisplayText = levelDisplay.GetComponent<GUIText>();
		coinTotal = GameObject.FindGameObjectsWithTag ("Collectible").Length;

		exit = GameObject.Find("Portal_All");
		exit.SetActive (false);
		generateLevels ();
		updateScoreDisplay ();


	}

	// Update is called once per frame
	void Update () {

	}
}

