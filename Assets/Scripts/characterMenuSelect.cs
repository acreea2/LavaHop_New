using UnityEngine;
using System.Text.RegularExpressions;

public class characterMenuSelect : MonoBehaviour {

	private float range = 100f;
	public Camera cam;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space)) {
			trySelection ();
		}

		if (Input.GetKey ("w")) {
			transform.Rotate (Vector3.left);
		}

		if (Input.GetKey ("s")) {
			transform.Rotate (Vector3.right);
		}
	}

	void trySelection() {
		RaycastHit hit;

		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, range)) {

			if (hit.transform.name == "MenuStart") {
				GameManager.instance.startGame ();
			}
			if (hit.transform.tag == "StartLevel") {
				string level = Regex.Match (hit.transform.parent.name, @"\d+").Value;
				GameManager.instance.startGame (int.Parse(level));
			}
		}
	}
}
