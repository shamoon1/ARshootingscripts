using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour {
 GameObject center;

	// Use this for initialization
	void Start () {
		center=GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Vector3.MoveTowards (this.transform.position,center.transform.position,Time.deltaTime*70);
		//transform.rotation = Quaternion.Slerp(transform.rotation, center.transform.rotation, Time.deltaTime * 50f);
		Destroy (this.gameObject, 20f);


	}
//	void OnTriggerEnter(Collider col){
//
//		if (col.tag == "player") {
//			print ("work");
//
//			Destroy (this.gameObject,0f);
//
//		}
	//}

}
