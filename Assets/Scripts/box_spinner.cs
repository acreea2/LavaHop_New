using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_spinner : MonoBehaviour {

	private float spinSpeed = 0.2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, spinSpeed, 0);
	}
}