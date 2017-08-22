using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour {

	public Rigidbody rb;
	public MyGameController gameController;
	public int score = 0;

	// Sound Arena
	public AudioSource SSCoins;
	public AudioClip Coins;

	public AudioSource SSJumpSound;
	public AudioClip Jump;

	public AudioSource SSLanding;
	public AudioClip Land;

	public AudioSource SSDeath;
	public AudioClip Death;

	public AudioSource SPortal;
	public AudioClip Portal;


	//	Jumps
	public float jumpPowerForward = 4f;
	public float jumpVelocityUp = 8f;

	private int jumpsRemaining;
	private int jumpTotal = 2;


	void Start()
	{
		rb = GetComponent<Rigidbody>();
		jumpsRemaining = jumpTotal;
	}

	private bool levelComplete() {
		return score >= 1;
//		return score >= gameController.coinTotal;
	}

	public void incrementScore() {
		score += 1;
		gameController.updateScoreDisplay ();
		if (levelComplete()) {
			gameController.showExit ();
		}
	}

	private void jump() {
		if (jumpsRemaining > 0) {
			SSJumpSound.PlayOneShot (Jump);

			jumpsRemaining -= 1;
			rb.velocity = new Vector3(0, jumpVelocityUp, 0);
			rb.AddForce (
				Vector3.Scale (
					Camera.main.transform.forward,
					new Vector3(jumpPowerForward, 0, jumpPowerForward)
				),
				ForceMode.Impulse
			);
		}
	}
		


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Platform") {
			transform.parent = other.transform;
			jumpsRemaining = jumpTotal;

			SSLanding.PlayOneShot (Land);
		}

		if (other.gameObject.tag == "Collectible") { // Gets coin
			Destroy (other.gameObject);
			incrementScore ();
			SSCoins.PlayOneShot (Coins);

			if (score == 5) {
				SPortal.PlayOneShot (Portal);
				Debug.Log("Large Portal Sound" + score);
			}
		}

		if (other.gameObject.tag == "Lava") { // Death by Lava
			StartCoroutine(dieAndReset ());
			SSDeath.PlayOneShot (Death);
			rb.useGravity = false;
			rb.velocity = new Vector3(0, -0.25f, 0);
			jumpsRemaining = 0;
		}

		if (other.gameObject.tag == "Portal") {
			gameController.incrementLevel ();
		}

	}

	IEnumerator dieAndReset() {
		yield return new WaitForSeconds(1.5f);
		gameController.reloadLevel();
		score = 0;
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Platform")
		{
			transform.parent = null;
		}
	}

	void Update () {
		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
			jump ();
		}
	}
}