using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Spin : MonoBehaviour {

	public GameObject coinInside;
	public GameObject coinOutside;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {


		coinOutside.transform.Rotate (0, .5f, 0);
		coinInside.transform.Rotate (.5f, .5f, .5f);
	}
}