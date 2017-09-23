using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour {

	public Rigidbody rb;
	public MyGameController gameController;
	public int score = 0;

	// Sound Arena
	private AudioSource audioSource;
	private AudioClip jumpClip;
	private AudioClip coinClip;
	private AudioClip landingClip;
	private AudioClip deathClip;
	private AudioClip portalClip;

	//	Jumps
	public float jumpPowerForward = 4f;
	public float jumpVelocityUp = 8f;

	private int jumpsRemaining;
	private int jumpTotal = 2;


	void Start()
	{
		rb = GetComponent<Rigidbody>();
		jumpsRemaining = jumpTotal;
		audioSource = (AudioSource)GetComponent<AudioSource>();

		jumpClip = (AudioClip) Resources.Load("Sounds/jump");
		coinClip = (AudioClip) Resources.Load("Sounds/coin");
		landingClip = (AudioClip) Resources.Load("Sounds/landing");
		deathClip = (AudioClip) Resources.Load("Sounds/death");
		portalClip = (AudioClip) Resources.Load("Sounds/portal");
	}

	private bool levelComplete() {
		return score >= 5;
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
			audioSource.PlayOneShot (jumpClip);

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

			audioSource.PlayOneShot (landingClip);
		}

		if (other.gameObject.tag == "Collectible") { // Gets coin
			Destroy (other.gameObject);
			incrementScore ();
			audioSource.PlayOneShot (coinClip);

			if (score == 5) {
				audioSource.PlayOneShot (portalClip);
				Debug.Log("Large Portal Sound" + score);
			}
		}

		if (other.gameObject.tag == "Lava") { // Death by Lava
			StartCoroutine(dieAndReset ());
			audioSource.PlayOneShot (deathClip);
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