using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMove : MonoBehaviour {

	public float scrollSpeed = 0.02F;
	public Renderer rend; // select your plane with this
	private float secondsForOneLength = 85f;

	void Start() {
		rend = GetComponent<Renderer>();
	}

	void Update() {
		rend.material.SetTextureOffset("_MainTex", Vector2.Lerp(
			new Vector2(0, 0),
			new Vector2(2.0f, 0),
			Mathf.SmoothStep(0f, 1f,
				Mathf.PingPong(Time.time/secondsForOneLength, 1f)
			)
		));
	}
}