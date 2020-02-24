using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour {
	

	public GameObject vfxdead;
	float xSpread;
	float zSpread ;
	float yOffset;
	public float speedaxis,movespeed,enemypowerdecrease;
	public static int count,i,work,stop;
	public static int enemylenth;
	public Transform centerPoint;
	public static float xposition, yposition, zposition;
	float rotSpeed;
	public bool rotateClockwise;

	float timer = 0;
	void Start () {
		xposition = this.transform.position.x;
		yposition = this.transform.position.y;
		zposition = this.transform.position.z;
		xSpread = xposition+Random.Range (-20.0f, 20.0f);
		yOffset = yposition;
		//zSpread = gameplayCode.zposition;

		i = 0;
		stop = 0;
		work = 0;
		enemylenth = 0;
		//FindObjectOfType<enemyhealth> ().EnemyBar.fillAmount = 1;
		gameplayCode.cooperon = 1;
		centerPoint = GameObject.FindGameObjectWithTag ("MainCamera").transform;
		count = 0;

		StartCoroutine ("Move");
	}

	// Update is called once per frame
	void Update () {
		

		transform.LookAt(centerPoint);
		timer += Time.deltaTime * rotSpeed;
	
		Rotate();		
	}

	IEnumerator Move() {


		while (true) {
			yield return new WaitForSeconds (speedaxis);
			if (work == 0) {
				count++;
				if (count == 1) {
					xSpread = xposition+Random.Range (-20.0f, 20.0f);
					zSpread = zposition+Random.Range (35.0f, 45.0f);
					yOffset = Random.Range (-2.0f, 2.5f);
					//rotSpeed = Random.Range (0.1f, 1.1f);
					rtot.attacks = 0;

				}
				if (count == 2) {
					xSpread = xposition+Random.Range (15.0f, 20.0f);
					zSpread = zposition+Random.Range (25.0f, 30.0f);
					yOffset = yposition+Random.Range (-5.0f, 5f);
					//rotSpeed = Random.Range (0.1f, 1.1f);


				}
				if (count == 3) {
					xSpread = xposition+Random.Range (-15.0f, -20.0f);
					zSpread = zposition+Random.Range (35.0f, 45.0f);
					yOffset = yposition+Random.Range (-2.0f, 2.5f);
					//rotSpeed = Random.Range (0.1f, 1.1f);

				}
				if (count == 4) {
					xSpread = xposition+Random.Range (15.0f, 20.0f);
					zSpread = zposition+Random.Range (25.0f, 30.0f);
					yOffset = yposition+Random.Range (-2.0f, 2.5f);
					//rotSpeed = Random.Range (0.1f, 1.1f);

				}
				if (count == 5) {
					xSpread = xposition+Random.Range (-15.0f, -20.0f);
					zSpread =zposition+ Random.Range (35.0f, 45.0f);
					yOffset = yposition+Random.Range (-5.0f, 5f);
					//rotSpeed = Random.Range (0.1f, 1.1f);

				}
				if (count == 6) {
					xSpread = xposition+Random.Range (-20.0f, 20.0f);
					zSpread = zposition+Random.Range (25.0f, 30.0f);
					yOffset = yposition+Random.Range (-2.0f, 2.5f);
					//rotSpeed = Random.Range (0.1f, 1.1f);

				}
				if (count == 7) {
					xSpread = xposition+Random.Range (-30.0f, 30.0f);
					zSpread = zposition+Random.Range (35.0f, 45.0f);
					yOffset = yposition+Random.Range (-5.0f, 5f);
					//rotSpeed = Random.Range (0.1f, 1.1f);
					Invoke ("ii", 1.0f);
				}

			}
		}
	}
	void OnTriggerEnter(Collider col){

		if (col.tag == "bullets") {
			if (menuCode.selectioncount == 1) {
				enemypowerdecrease += 40;
				FindObjectOfType<enemyhealth> ().Hitt (enemypowerdecrease);
			} else {
				FindObjectOfType<enemyhealth> ().Hitt (enemypowerdecrease);
			}
				if (FindObjectOfType<enemyhealth> ().EnemyBar.fillAmount <= 0) {
					if (stop == 0) {
						enemylenth = 1;
						//this.gameObject.SetActive (false);
						gameplayCode.cooperon = 0;

					Invoke ("expolde",0.3f);
						
						Destroy (this.gameObject, 2f);
						stop = 1;
					}
				vfxdead.SetActive (true);
				}


		}
	}
	void expolde(){
		FindObjectOfType<Explosion> ().explode ();
	}

	void Rotate() {




	/*	if(rotateClockwise) {

			/*float x = -Mathf.Cos (timer) * xSpread;
				float z = Mathf.Sin (timer) * zSpread;
			Vector3 pos = new Vector3 (xSpread, yOffset, zSpread);

			transform.position = Vector3.MoveTowards (transform.position, pos + centerPoint.position,Time.deltaTime*4);

		} else {*/
			/*float x = Mathf.Cos(timer) * xSpread;
			float z = Mathf.Sin(timer) * zSpread;*/

		Vector3 pos = new Vector3(xSpread, yOffset,zSpread);
		
			transform.position = Vector3.MoveTowards (transform.position, pos + centerPoint.position,Time.deltaTime*movespeed);
		//}
	}
	// Use this for initialization
	/*void Start () {
		StartCoroutine ("Move");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * 5f * Time.deltaTime);
		//transform.Translate (Vector3.down * 5f * Time.deltaTime);
	}
	IEnumerator Move() {


		while (true) {
			yield return new WaitForSeconds (3.5f);
			transform.eulerAngles += new Vector3 (0, 180f, 0);
		}
	}
	/*IEnumerator switchright () {
		yield return new WaitForSeconds (1);
		transform.Translate (Vector3.right * 3f);

	}*/
	public void ii(){
		i = 1;
	}

}
