using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning_Coins : MonoBehaviour {


	public float spinSpeed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, spinSpeed, 0);
	}
}