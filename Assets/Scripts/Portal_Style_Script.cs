using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Style_Script : MonoBehaviour {

	public GameObject portalOutside;
	public GameObject portalInside;

	public GameObject floor1;
	public GameObject floor2;
	public GameObject floor3;

	public Transform farEnd1;
	private Vector3 frometh1;
	private Vector3 untoeth1;

	public Transform farEnd2;
	private Vector3 frometh2;
	private Vector3 untoeth2;

	private float secondsForOneLength = 1.5f;

	// Use this for initialization
	void Start () {

		frometh1 = floor1.transform.position;
//		frometh1 = transform.position;
		untoeth1 = farEnd1.position;

		frometh2 = floor2.transform.position;
//		frometh2 = transform.position;
		untoeth2 = farEnd2.position;
	}

	// Update is called once per frame
	void Update () {

		portalInside.transform.Rotate (0, 0.2f, 0);
		portalOutside.transform.Rotate (0, -0.2f, 0);

		floor1.transform.position = Vector3.Lerp (frometh1, untoeth1, Mathf.SmoothStep (0f, 1f, Mathf.PingPong (Time.time / secondsForOneLength, 1f)
		));

		floor2.transform.position = Vector3.Lerp (frometh2, untoeth2, Mathf.SmoothStep (0f, 1f, Mathf.PingPong (Time.time / secondsForOneLength, 1f)
		));
			
	}
}

