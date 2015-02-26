using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public float rate = 1.0f;
	public float damage = 0.0f;
	public string name = "";
	public bool isRoulette = false;
	public bool isDefault = false;
	public bool isActive = false;

	private AudioSource shootingSound;

	// Use this for initialization
	void Start () {
		shootingSound = GetComponent<AudioSource> ();

		if (isDefault == false) {
			Disable();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Enable() {
		isActive = true;
		Renderer[] renderers = GetComponentsInChildren<Renderer> ();
		for (int i = 0; i < renderers.Length; i++) {
			renderers[i].enabled = true;
		}
	}

	public void Disable() {
		isActive = false;
		Renderer[] renderers = GetComponentsInChildren<Renderer> ();
		for (int i = 0; i < renderers.Length; i++) {
			renderers[i].enabled = false;
		}
	}

	public void PlaySound() {
		shootingSound.enabled = true;
		shootingSound.mute = false;
		shootingSound.Play ();
	}
}
