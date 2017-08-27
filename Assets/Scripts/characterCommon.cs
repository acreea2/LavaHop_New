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

//		if (Input.GetKey ("w")) {
//			transform.Rotate (Vector3.left);
//		}

//		if (Input.GetKey ("s")) {
//			transform.Rotate (Vector3.right);
//		}
	
	}
}
