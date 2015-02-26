using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public int damage = 10;
	public float cadence = 0.15f;
	float timer;

	ParticleSystem gunParticle;
	Light gunLight;
	LineRenderer gunLine;
	Ray shootRay; // Ligne infinie
	RaycastHit shootHit;
	PlayerRobot robot;


	// Use this for initialization
	void Start () {
		gunParticle = GetComponent<ParticleSystem>();
		gunLine = GetComponent<LineRenderer>();
		gunLight = GetComponent<Light>();
		robot = transform.parent.GetComponent<PlayerRobot> ();
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		// Si le joueur shoot et que le temps entre 2 tirs est inférieur à la cadence
		if (robot.id == 1) {
			if (Input.GetButton ("FireRobot1") && timer >= cadence) {
				Debug.Log ("test1");
				Shoot ();
			} else {
				stopShoot ();
			}
		} else if (robot.id == 2) {
			if (Input.GetButton ("FireRobot2") && timer >= cadence) {
				Debug.Log ("test2");
				Shoot ();
			} else {
				stopShoot ();
			}
		}

		
	}

	void Shoot () {
		timer = 0;

		gunLight.enabled = true;

		gunParticle.Stop ();
		gunParticle.Play ();

		gunLine.enabled = true;
//		gunLine.SetPosition (0, transform.position);

		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;


		gunLine.SetPosition (0, transform.position + shootRay.direction * 10);
		gunLine.SetPosition (1, transform.position);


		//Si rayon touche objet

		if (Physics.Raycast (shootRay, out shootHit)) {
			PlayerRobot playerHit = shootHit.collider.GetComponent<PlayerRobot> ();

			if (playerHit != null) {
				playerHit.ReceiveDamages(25);
			}
		}
	}

	void stopShoot () {
		gunLine.enabled = false;
		gunLight.enabled = false;
	}

}
