using UnityEngine;

public class characterCommon : MonoBehaviour
{
	void Update ()
	{
		if (Input.GetKey ("a")) {
			transform.Rotate (Vector3.down);
		}

		if (Input.GetKey ("d")) {
			transform.Rotate (Vector3.up);
		}
	
	}
}
