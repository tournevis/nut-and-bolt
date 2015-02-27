using UnityEngine;
using System.Collections;

public class turretShoot : MonoBehaviour {
	public float duration ; 
	public float interval ;
	private float lastUp;
	private float timeUpOn ;
	private float timeUpOff ; 
	Animator anim;
	Rigidbody turretRigid;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Level.paused)
			return;

		timeUpOn += Time.deltaTime; 
		timeUpOff += Time.deltaTime; 

		if (timeUpOn >= interval) {
			Debug.Log ("Turret On");
			anim.speed = 3;
			anim.SetBool ("shooting", true);
			timeUpOn = 0;
		} 

		if(timeUpOff >= interval + 1 ){
			Debug.Log ("Turret Off");
			anim.speed = -3;
			anim.SetBool ("shooting", false);
			//animation.Stop ();
			timeUpOff = 0;
		}

		//if (Time.time - lastUp + duration   >= interval) {
		//	Debug.Log ("Turret Off");
		//	anim.SetBool("shooting" , true);
		//	anim.speed = -3 ;
		//	lastUp = Time.time;
		//}
	}
}
