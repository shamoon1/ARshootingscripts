using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level1 : MonoBehaviour {
	public static int g,lele,ghoostn;
	public Rigidbody cooper1;
	public Transform point;

	private int my_Scene;
	public int ends;
	// Use this for initialization
	void Start () {
		
		enemyScript.enemylenth = 1;
		//ghoostn=0;
		lele=0;
		my_Scene = SceneManager.GetActiveScene ().buildIndex;
		g = 0;
		//Invoke ("lateinsate",3f);
	}
	
	// Update is called once per frame
	void Update () {

			if (g < ends) {

				if (enemyScript.enemylenth  == 1) {
					Invoke ("lateinsate", 3f);
					g++;
					enemyScript.enemylenth  = 0;
				}
			}
			if(g==ends){  
				if (enemyScript.enemylenth  == 1) {
					FindObjectOfType<gameplayCode> ().playMenuCount (13);
			
					Invoke ("cleared", 5f);
					enemyScript.enemylenth  = 0;
					g = 100;
				}
			}


//		if(my_Scene==3||my_Scene==4){
//			if (g < ends) {
//						
//				if (enemyScript.enemylenth  == 1) {
//					if(checktext.working==0){
//					Invoke ("ghoost2ss", 3f);
//					g++;
//						checktext.working = 1;
//						enemyScript.enemylenth  = 0;
//					}
//				}
//			} 
//			if(g==ends){  
//				if (enemyScript.enemylenth  == 1) {
//					FindObjectOfType<gameplayCode> ().playMenuCount (13);
//					//victoryvfx.SetActive (true);
//					Invoke ("cleared", 5f);
//					enemyScript.enemylenth  = 0;
//					g = 100;
//				}
//			}
//			
//		}
//
//		if(my_Scene==5||my_Scene==6){
//			if (g < ends) {
//
//				if (enemyScript.enemylenth  == 1) {
//					Invoke ("ghoost3ss", 3f);
//					g++;
//					enemyScript.enemylenth  = 0;
//				}
//			} 
//			if(g==ends){  
//				if (enemyScript.enemylenth == 1) {
//					FindObjectOfType<gameplayCode> ().playMenuCount (13);
//				//	victoryvfx.SetActive (true);
//					Invoke ("cleared", 5f);
//					enemyScript.enemylenth  = 0;
//					g = 100;
//				}
//			}
//
//		}
	}
	public void lateinsate(){
		Rigidbody insantiate;
		insantiate = Instantiate (cooper1, point.position, point.rotation)as Rigidbody;
		//Invoke ("rotot",1f);
	}
//	public void ghoost2ss(){
//		Rigidbody insa;
//		insa = Instantiate (ghoost2, point.position, point.rotation)as Rigidbody;
//		//Invoke ("rotot",1f);
//	}
//	public void ghoost3ss(){
//		Rigidbody inss;
//		inss = Instantiate (ghoost3s, point.position, point.rotation)as Rigidbody;
//		//Invoke ("rotot",1f);
//	}
	public void cleared(){
		
		FindObjectOfType<gameplayCode> ().playMenuCount (3);
	}
	//	public void levelwork(int ends){
	//		if (g < ends) {
	//			
	//			if (enemylenth == 1) {
	//				Invoke ("lateinsate", 5f);
	//				g++;
	//				enemylenth = 0;
	//			}
	//		}
	//
	//		if (SceneManager.GetActiveScene ().buildIndex == 3) {
	//			if (g ==ends) {
	//
	//				if (enemylenth == 1) {
	//					
	//					Invoke ("lateinsateghoost", 5f);
	//					g++;
	//					enemylenth = 0;
	//				}
	//			}
	//			if (g == ends+1) {
	//				if (enemylenth == 1) {
	//					g++;
	//					enemylenth = 0;
	//				}
	//			}
	//			if (g == ends+2) {
	//			    FindObjectOfType<gameplayCode> ().playMenuCount (13);
	//				victoryvfx.SetActive (true);
	//				Invoke ("cleared", 5f);
	//			}
	//			
	//		} else {
	//
	//			if (g == ends) {
	//			 
	//
	//		
	//				FindObjectOfType<gameplayCode> ().playMenuCount (13);
	//				victoryvfx.SetActive (true);
	//				Invoke ("cleared", 5f);
	//			}
	//
	//		}
	//	}
	//	

}
