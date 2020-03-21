using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class powercript : MonoBehaviour {
	public Image healthBar,sheild;
	public GameObject blood;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col){

		if (col.tag == "fireball") {
			Destroy (col.gameObject);
			GetComponent<AudioSource> ().Play ();
			sheild.fillAmount = sheild.fillAmount - 0.1f;
			blood.SetActive (true);
			Invoke ("bloodss",0.5f);
			if (sheild.fillAmount <= 0) {

				healthBar.fillAmount = healthBar.fillAmount - 0.1f;
				if (healthBar.fillAmount <= 0) {
					FindObjectOfType<gameplayCode> ().playMenuCount (4);
				}
			}

		}
	}
	void bloodss(){
		blood.SetActive (false);
	}
}
