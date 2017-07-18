using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour {

	public GameObject spawnPoint;

	// Use this for initialization
	void Start () {
//		respawnPosition.position = GameObject.FindGameObjectWithTag ("Spawn").transform.position;

	}
	
	// Update is called once per frame
	void Update () {
	}


	void OnTriggerEnter (Collider col)
	{
		if(col.transform.tag == "Lava")
		{

			this.transform.position = spawnPoint.transform.position;
		}
	}
		
}
