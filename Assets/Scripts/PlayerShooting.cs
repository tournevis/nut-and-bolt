using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	private float damage = 10.0f;
	private float cadence = 0.15f;
	float timer;

	ParticleSystem gunParticle;
	Light gunLight;
	LineRenderer gunLine;
	Ray shootRay;
	RaycastHit shootHit;
	PlayerRobot robot;
	Weapon weapon;
	AudioSource shootingSound; // Audio


	// Use this for initialization
	void Start () {
		gunParticle = GetComponent<ParticleSystem>();
		gunLine = GetComponent<LineRenderer>();
		gunLight = GetComponent<Light>();
		shootingSound = GetComponent<AudioSource> ();
		robot = transform.parent.parent.parent.parent.GetComponent<PlayerRobot> (); // Sorry for this ugly stuff
		weapon = robot.weapon;
		cadence = weapon.rate;
		damage = weapon.damage;

	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		// Si le joueur shoot et que le temps entre 2 tirs est inférieur à la cadence
		if (robot.id == 0) {
			if (Input.GetButton ("FireRobot1") && timer >= cadence) {
				Shoot ();
			} else {
				stopShoot ();
			}
		} else if (robot.id == 1) {
			if (Input.GetButton ("FireRobot2") && timer >= cadence) {
				Shoot ();
			} else {
				stopShoot ();
			}
		}		
	}

	void Shoot () {

//		Debug.Log (shootingSound.clip);
		shootingSound.mute = false;
		shootingSound.Play ();

		weapon = robot.weapon;
		cadence = weapon.rate;
		damage = weapon.damage;

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

		if(weapon.isRoulette) {
			int r = Random.Range(1, 6);
			if(r != 6) {
				// Shoot on player
				robot.ReceiveDamages(weapon.damage);

				return;
			}
		}

		if (Physics.Raycast (shootRay, out shootHit)) {
			PlayerRobot playerHit = shootHit.collider.GetComponent<PlayerRobot> ();

			if (playerHit != null) {
				playerHit.ReceiveDamages(weapon.damage);
			}
		}
	}

	void stopShoot () {
		gunLine.enabled = false;
		gunLight.enabled = false;
	}

}
