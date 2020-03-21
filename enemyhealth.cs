using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemyhealth : MonoBehaviour {
	public float helth,maxhealth;

	public Image EnemyBar;
	// Use this for initialization
	void Start () {
		EnemyBar.fillAmount = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Hitt(float damge)
	{
		helth -= damge;
		EnemyBar.fillAmount = helth / maxhealth;
	}

}
