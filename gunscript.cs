using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gunscript : MonoBehaviour {
	public Rigidbody rigid,rigid2;
	public Transform body;
	public Text bulletcount;
	public int bcount;

	public GameObject reloadImage,btnreload;
	// Use this for initialization
	private Animation anim;
	// Use this for initialization
	void Start () {
		reloadImage.SetActive (false);
		anim = GetComponentInChildren<Animation>();
	}
	// Update is called once per frame
	void Update () {

		bulletcount.text = bcount.ToString ();
	}

	public void OnButtonDown(){
		if (bcount > 0) {
			GetComponent<AudioSource> ().Play ();
			bcount--;
			//gunanims ();
			//GameObject bullet = Instantiate(Resources.Load("bullet", typeof(GameObject))) as GameObject;

		
			//insantiate.velocity =transform.TransformDirection(Vector3.forward * 70f);
			if (menuCode.selectioncount == 0) {
				Rigidbody insantiate;
				insantiate = Instantiate (rigid, body.position, body.rotation)as Rigidbody;
				insantiate.velocity = transform.forward * 50;
			}
			if (menuCode.selectioncount == 1) {
				Rigidbody insantiate;
				insantiate = Instantiate (rigid2, body.position, body.rotation)as Rigidbody;
				insantiate.velocity = transform.TransformDirection(Vector3.forward* 80);
			}
			//Destroy (bullet, 3);


			/*GameObject bullet = Instantiate(Resources.Load("bullet", typeof(GameObject))) as GameObject;
		/*Rigidbody rb = bullet.GetComponent<Rigidbody>();
		bullet.transform.rotation = Camera.main.transform.rotation;
		bullet.transform.position = Camera.main.transform.position;
		rb.AddForce(Camera.main.transform.forward * 500f);
		Destroy (bullet, 3);

		GetComponent<AudioSource> ().Play ();*/

		} else {
			reloadImage.SetActive (true);
			Invoke ("reloadImg",3f);
			//print ("reload");
		}
	}
	public void reloadImg(){
		
		reloadImage.SetActive (false);
	}
	public void reloadbtnfn(){
		reloadImage.SetActive (false);
		btnreload.GetComponent<AudioSource> ().Play ();
		if (menuCode.selectioncount == 1) {
			bcount = 20;
		} else {
			bcount = 10;
		}
	}
	/*public void gunanims(){

		anim.CrossFade ("gunanim");
	}*/
}
