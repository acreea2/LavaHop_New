using UnityEngine;
using System.Text.RegularExpressions;

public class characterMenuSelect : MonoBehaviour {

	private float range = 1000f;
	public Camera cam;
	public Material startBackground;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space)) {
			trySelection ();
		}
	}

	void OnMouseOver()
	{
		print (gameObject.name);
	}

	void trySelection() {
		RaycastHit hit;

		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, range)) {

			if (hit.transform.name == "MenuStart") {
				GameManager.instance.startGame ();
				Debug.Log("Start");
			}
			if (hit.transform.tag == "StartLevel") {
				string level = Regex.Match (hit.transform.parent.name, @"\d+").Value;
				GameManager.instance.startGame (int.Parse(level));
				Debug.Log("Start Level");

			}
			if (hit.transform.tag == "Exit") {
				GameManager.instance.exit ();
			}

			if (hit.transform.tag == "StartLevel") {

				Debug.Log("Start Level RayTraced");
//				Color transparencyColor = new Color(1, 1, 1, 0.01f);
//				Renderer startBackground;
//				tempRenderer = theCollision.renderer;
//				self.startBackground.material.color.a = 0.01f;
			}
		}
	}
}
