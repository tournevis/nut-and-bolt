using UnityEngine;
using System.Collections;

public class openCloseRight : MonoBehaviour {

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
		transform.GetComponent<Animator> ().SetBool ("trapRight", true);
	}
	
	public void closeTrap () {
		Debug.Log ("Test");
		transform.GetComponent<Animator> ().SetBool ("trapRightClose", true);
	}
}