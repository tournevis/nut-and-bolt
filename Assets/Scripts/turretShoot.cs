using UnityEngine;
using System.Collections;

public class turretShoot : MonoBehaviour {

	public float interval ; 
	
	private float damage = 10.0f;
	private float cadence = 0.15f;
	public float timeUpOn;
	float timer;

	Light gunLight;
	LineRenderer gunLine;
	Ray shootRay;
	RaycastHit shootHit;
	PlayerRobot robot;
	Animator anim;
	
	// Use this for initialization
	void Start () {
		gunLine = GetComponent<LineRenderer>();
		gunLight = GetComponent<Light>();

		anim = GetComponent<Animator> ();
	}

	
	// Update is called once per frame
	void Update () {

		if (Level.paused)
			return;

		timeUpOn += Time.deltaTime; 
		if (timeUpOn >= interval/2) {
			anim.SetBool ("shooting", true);
			//Shoot ();	
		} 
		if (timeUpOn >= interval) {
			anim.SetBool ("shooting", false);
			//Shoot ();	
			timeUpOn = 0;
		} 
		

	}
	void Shoot () {

		timer = 0;

		gunLight.enabled = true;

		gunLine.enabled = true;

		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;


		gunLine.SetPosition (0, transform.position + shootRay.direction * 10);
		gunLine.SetPosition (1, transform.position);

		//Si rayon touche objet

		if (Physics.Raycast (shootRay, out shootHit)) {
			PlayerRobot playerHit = shootHit.collider.GetComponent<PlayerRobot> ();

			if (playerHit != null) {
				playerHit.ReceiveDamages(20);
			}
		}
	}

	void stopShoot () {
		gunLine.enabled = false;
		gunLight.enabled = false;
//		shootingSound.enabled = false;
	}

}

