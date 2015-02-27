using UnityEngine;
using System.Collections;

public class turretShoot : MonoBehaviour {

	public float interval ; 
	public float damage;
	public float timeUpOn;

	Light gunLight;
	LineRenderer gunLine;
	Ray shootRay;
	RaycastHit shootHit;
	PlayerRobot robot;
	Animator anim;
	
	// Use this for initialization
	void Start () {
		gunLine = GetComponentInChildren<LineRenderer>();
		gunLight = GetComponentInChildren<Light>();

		anim = GetComponent<Animator> ();
	}

	
	// Update is called once per frame
	void Update () {
		if (Level.paused)
			return;

		timeUpOn += Time.deltaTime; 

		if (timeUpOn >= interval/2) {
			anim.SetBool ("shooting", true);
			transform.Rotate(0.0f, 30.0f * Time.deltaTime, 0.0f);
			gunLine.transform.Rotate(0.0f, 30.0f * Time.deltaTime, 0.0f);

			if(timeUpOn >= interval/2 + 1.0f) {
				Shoot();
			}

		} 
		if (timeUpOn >= interval) {
			anim.SetBool ("shooting", false);
			stopShoot ();	
			timeUpOn = 0;
		} 
		

	}
	void Shoot () {

		Vector3 o = new Vector3 (transform.position.x, transform.position.y + 4.0f, transform.position.z);

		gunLight.enabled = true;
		gunLine.enabled = true;
		
		shootRay.origin = o;
		shootRay.direction = -transform.forward;


		gunLine.SetPosition (0, o);
		gunLine.SetPosition (1, o + shootRay.direction * 50);

		//Si rayon touche objet

		if (Physics.Raycast (shootRay, out shootHit)) {
			PlayerRobot playerHit = shootHit.collider.GetComponent<PlayerRobot> ();

			if (playerHit != null) {
				playerHit.ReceiveDamages(damage);
			}

			gunLine.SetPosition (1, shootHit.point);
		}
	}

	void stopShoot () {
		gunLine.enabled = false;
		gunLight.enabled = false;
//		shootingSound.enabled = false;
	}

}

