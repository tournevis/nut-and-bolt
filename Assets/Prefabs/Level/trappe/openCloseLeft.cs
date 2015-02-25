using UnityEngine;
using System.Collections;

public class openCloseLeft : MonoBehaviour {

	public float aleaTimeOpen = 0;
	public float aleaTimeClose = 3;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		aleaTimeOpen -= Time.deltaTime; 
//		
//		if(aleaTimeOpen <= 0) {
//			openTrap();
//			aleaTimeClose -= Time.deltaTime; 
//			
//			if(aleaTimeClose <= 0) {
//				closeTrap();
//			}
//		}
		
	}
	
	public void openTrap () {
		transform.GetComponent<Animator> ().SetBool ("trapLeft", true);
	}
	
	public void closeTrap () {
		transform.GetComponent<Animator> ().SetBool ("trapLeftClose", true);
	}
}