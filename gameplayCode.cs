using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class gameplayCode : MonoBehaviour {
	public GameObject[] playItems,guns;
	public Rigidbody cooper1;

	//public GameObject enemycube;
	public GameObject victoryvfx;
	public Transform point;
	private int menuCounter,my_Scene;
	public static int cooperon;
	public float time;
	private int minutes;
	public AudioSource fir_sound,gamesound;
	private int seconds,timestart;

	public Text TimeText;
	// Use this for initialization
	void Start () {
		
		timestart = 0;
		cooperon = 1;
		//cooper1.SetActive (true);
      menuCode.selectioncount=1;
		Invoke ("playscreen",5f);
		victoryvfx.SetActive (false);
	
		my_Scene = SceneManager.GetActiveScene ().buildIndex;
	}
//	public void enemycubes(){
//		//Rigidbody insantiate;
//		//insantiate = Instantiate (cooper1, point.position, point.rotation)as Rigidbody;
//		//Invoke ("rotot",1f);
//	
//	}

	// Update is called once per frame
	void Update () {
		
		fir_sound.volume = PlayerPrefs.GetFloat ("MainSound");
		gamesound.volume = PlayerPrefs.GetFloat ("MainSound");
		///timeif(joycount.Equals (1)){
		if (timestart ==1) {
			time -= Time.deltaTime;
			minutes = (int)time / 60;
			seconds = (int)time % 60;
			TimeText.text = string.Format ("{0:00}:{1:00}", minutes, seconds);
			if (time <= 0) {
				time = 0;
				enemyScript.work = 0;
				enemyScript.count = 0;
				enemyScript.i= 0;
				playMenuCount (4);
		
			}
		}//
		
		for (int i = 0; i < playItems.Length; i++) {
			if (i == menuCounter) {
				playItems [i].SetActive (true);

			} else {
				playItems [i].SetActive (false);
			}
		}
		for (int i = 0; i < guns.Length; i++) {
			if (i == menuCode.selectioncount) {
				guns [i].SetActive (true);

			} else {
				guns [i].SetActive (false);
			}
		}
	}
	public void playMenuCount(int value)
	{

		menuCounter = value;
		if (value == 1) {
			timestart = 1;
			enemyScript.count = 0;
			enemyScript.i = 0;
			if (cooperon == 1) {
				enemyScript.work = 0;
				enemyScript.count = 0;
				enemyScript.i= 0;
			//enemycube.GetComponent<rtot> ().enabled = true;
			}
		} else {
			timestart = 0;
			if (cooperon == 1) {
				enemyScript.work = 1;
				//enemycube.GetComponent<rtot> ().enabled = false;
			}
		}
		if(value==3)
		{		victoryvfx.SetActive (true);
			//PlayerPrefs.SetInt ("GameScore", PlayerPrefs.GetInt ("GameScore") + 100);
			Clearedonclick ();
		}


	}
	public void Restartonclick()
	{
		
		SceneManager.LoadScene (my_Scene, LoadSceneMode.Single);

	}
	public void Menuclick()
	{
		SceneManager.LoadSceneAsync ("ghoostMenu");

	}
	public void Nextclick()
	{
		SceneManager.LoadScene (my_Scene + 1);

	}
	public void Clearedonclick()
	{

		PlayerPrefs.SetInt ("level"+my_Scene,1);

		//Time.timeScale = 0;

	}
	public void playscreen(){
		//playMenuCount (1);
		FindObjectOfType<gameplayCode> ().playMenuCount (1);
	}
}
