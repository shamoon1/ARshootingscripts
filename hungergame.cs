using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rtot : MonoBehaviour {
	public Transform target,centerPoint;
	public GameObject storm;
	public Rigidbody rigid;
	public Transform body;
	public float timer;
	public static int attacks;
	public Transform[] raycast;

	// Use this for initialization
	void Start () {
		attacks = 0;
		centerPoint = GameObject.FindGameObjectWithTag ("MainCamera").transform;
	}
	
	// Update is called once per frame
	void Update () {
		

			
		if(enemyScript.i==1){
		transform.RotateAround(target.transform.position, Vector3.down, 30);
			storm.SetActive (true);
			Invoke ("latee",2f);
			if(attacks==0){
			Invoke ("AttackCount", 0f);
				attacks = 1;
				StartCoroutine(ShootDelay());
			

			}


		//	transform.Translate (Vector3.right * Time.deltaTime);
		}
	}
	public void latee(){
		transform.LookAt (centerPoint);
		enemyScript.i = 0;
		storm.SetActive (false);
		enemyScript.count = 0;
	}
	public void stopattack(){
		attacks = 1;
	}
	public void AttackCount(){
		
		Rigidbody insantiate;
		insantiate = Instantiate (rigid, body.position, body.rotation)as Rigidbody;
		insantiate.velocity = transform.TransformDirection (Vector3.forward);
		//Vector3.MoveTowards(transform.position,centerPoint.position,5f)

	}
	IEnumerator ShootDelay()
	{
		yield return new WaitForSeconds(0.8f);
		attacks = 0;
	}

}
