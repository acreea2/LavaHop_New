using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	private float startTime;
	private Text displayText;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		displayText = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		displayText.text = formatTime(timeElapsed());
	}

	public float timeElapsed() {
		return Time.time - startTime;
	}

	public static string formatTime(float t) {
		float minutes = ((int)t / 60);
		float seconds = (t % 60);

		return leadingZeros(minutes) + ":" + leadingZeros(seconds);
	}

	static string leadingZeros(float num) {
		return (num < 10)
			? "0" + num.ToString("f2")
			: num.ToString("f2");
	}
}