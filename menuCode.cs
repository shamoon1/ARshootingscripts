using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuCode : MonoBehaviour {
	public GameObject[] menu_items,selection,lockbtn;
	public static int number;
	public GameObject unlock,selectbtn,not_enough_cash,pricebox,lvl_next;
	public static int selectioncount,lvl_no;
	public Text coins,price,levelcoin;
	public AudioSource btn_sound;
	public AudioClip slip;
	public Slider soundslider;
	// Use this for initialization
	void Start () {
		number = 0;
		//soundslider.value = 1;
		//PlayerPrefs.DeleteAll ();
		//PlayerPrefs.SetInt ("GameScore",600);
		//PlayerPrefs.SetInt ("level2",1);
		lvl_next.SetActive (false);
		coins.text = PlayerPrefs.GetInt ("GameScore").ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetFloat ("MainSound",soundslider.value);
		btn_sound.volume = PlayerPrefs.GetFloat ("MainSound");
		// level loop-------
		for (int i = 0; i < lockbtn.Length; i++) {
			if (PlayerPrefs.GetInt ("level" + (i + 1)).Equals (1)) {
				lockbtn [i+1].GetComponent<Button>().interactable = true;
			}
		}
		//----===
		levelcoin.text = PlayerPrefs.GetInt ("GameScore").ToString ();
		coins.text = PlayerPrefs.GetInt ("GameScore").ToString ();
		price.text = (selectioncount*500).ToString ();
		for (int i = 0; i < menu_items.Length; i++) {
			if (i.Equals (number)) {
				menu_items [i].SetActive (true);
			} else {
				menu_items [i].SetActive (false);
			}
		}
		for (int i = 0; i < selection.Length; i++) {
			if (i == selectioncount) {
				selection [i].SetActive (true);
			} else {
				selection [i].SetActive (false);
			}
		}

		if (PlayerPrefs.GetInt ("unlock" + selectioncount )== 1) 
		{
			pricebox.SetActive (false);
			unlock.SetActive (false);
			selectbtn.SetActive (true);
		}
		else 
		{
			if (selectioncount == 0) 
			{unlock.SetActive (false);
				pricebox.SetActive (false);
				selectbtn.SetActive (true);
			} 
			else {
				pricebox.SetActive (true);
				unlock.SetActive (true);
				selectbtn.SetActive (false);
			}
		}
		
	}
	public void item_value(int value)
	{
		btn_sound.PlayOneShot (slip,1);
		number = value;
		if(value==0){
			lvl_next.SetActive (false);
		}

	}


	// level onclick-----
	public void onclick_lvl(int level_value)
	{btn_sound.PlayOneShot (slip,1);
		lvl_next.SetActive (true);
		lvl_no = level_value;
	}
	// level onload-------
	public void onclick_lvl_load()
	{      item_value (5);
		Invoke ("loadlevel",5f);

	}
	// loadlevel 
	public void loadlevel(){
		SceneManager.LoadSceneAsync (lvl_no);

	}

	public void Right()
	{btn_sound.PlayOneShot (slip,1);
		if (selectioncount < selection.Length) {
			selectioncount++;
			PlayerPrefs.SetInt ("selectPlayer", selectioncount);
		}
		if (selectioncount == selection.Length) {
			selectioncount = 0;
			PlayerPrefs.SetInt ("selectPlayer", selectioncount);
		}
	}
	public void Exit_Yes_Button()
	{
		Application.Quit ();
	}
	public void playClickSound() {
		btn_sound.enabled = true;
	}
	public void NotplayClickSound() {
		//btn_sound.enabled = false;
	}
	public void onclick_buy()
	{
		if (PlayerPrefs.GetInt ("GameScore") >= (500*selectioncount)) {
			PlayerPrefs.SetInt ("GameScore", PlayerPrefs.GetInt ("GameScore") - (500*selectioncount));
			PlayerPrefs.Save ();
			PlayerPrefs.SetInt ("unlock"+selectioncount, 1);
		}
		else 
		{
			not_enough_cash.SetActive (true);
			Invoke("not_E_cash",2f);
		}
	}
	public void not_E_cash()
	{
		not_enough_cash.SetActive (false);
	}
}
