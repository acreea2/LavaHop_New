using UnityEngine;
using System.Text.RegularExpressions;

public class characterMenuSelect : MonoBehaviour {

	private float range = 1000f;
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
			if (hit.transform.tag == "StartLevel") {
				string level = Regex.Match (hit.transform.parent.name, @"\d+").Value;
				GameManager.instance.startGame (int.Parse(level));
			}
			if (hit.transform.tag == "Exit") {
				GameManager.instance.exit ();
			}
		}
	}
}
