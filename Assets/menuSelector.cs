using UnityEngine;

public class menuSelector : MonoBehaviour {

	private float range = 100f;
	public Camera cam;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space)) {
			trySelection ();
		}
	}

	void trySelection() {
		RaycastHit hit;

		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, range)) {
			if (hit.transform.name == "MenuStart") {
				GameManager.instance.startGame ();
			}
		}
	}
}
