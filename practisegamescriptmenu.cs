using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class practisegamescriptmenu : MonoBehaviour
{
    public GameObject[] menu_items, players, levels;
    public int number, playerNumber, lvl_no, clr_no;
    public GameObject unlock, selects,loadButon;
  //  public Material[] colors;
    public Text coins, price;
    public Slider menuSound, gamePlaySound;
    public AudioSource menusource;
    public bool fired;

    // Start is called before the first frame update
    void Start()
    {
        number = 6;
           fired = false;
           //players[0].GetComponent<MeshRenderer>().material = colors[0];
        loadButon.SetActive(false);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("GameScore", 10000);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("MenuSound", menuSound.value);

        PlayerPrefs.SetFloat("GameSound", gamePlaySound.value);
        menusource.volume = PlayerPrefs.GetFloat("MenuSound");


         
        price.text = (7000 * playerNumber).ToString();
        coins.text = PlayerPrefs.GetInt("GameScore").ToString();

        for (int i = 0; i < menu_items.Length; i++)
        {
            if (i == number)
            {
                menu_items[i].SetActive(true);
            }
            else
            {
                menu_items[i].SetActive(false);
            }
        }
        //player section.....................................................................
        for (int i = 0; i < players.Length; i++)
        {
            if (i == playerNumber)
            {
                players[i].SetActive(true);
             
               

               
            }
            else
            {
                players[i].SetActive(false);
            }

        }

   




        //Buy loop------------------------------------------------------------------------------------------------------------------
        if (PlayerPrefs.GetInt("unlock" + playerNumber) == 1)
        {
            unlock.SetActive(false);
            selects.SetActive(true);
        }
        else
        {
            if (playerNumber == 0)
            {
                unlock.SetActive(false);
                selects.SetActive(true);
            }
            else
            {
                unlock.SetActive(true);
                selects.SetActive(false);
            }
        }
        //level loop------------------------------------------------------------------------------------------------------------------
        for (int i = 0; i < levels.Length; i++)
        {
            if (PlayerPrefs.GetInt("level" + (i + 1)).Equals(1))
            {
                levels[i + 1].GetComponent<Button>().interactable = true;
            }
        }
    }
    public void menuFunction(int val)
    {
        number = val;
    }
    public void right()
    {
        if (playerNumber < players.Length - 1)
        {
            playerNumber++;
        }
        else if (playerNumber == players.Length - 1)
        {
            playerNumber = 0;
        }
    }
    public void left()
    {
        if (playerNumber > 0)
        {
            playerNumber--;
        }
        else if (playerNumber == 0)
        {
            playerNumber = players.Length - 1;
        }
    }
    //buy function------------------------------------------------------------------------------------------------------------------
    public void onclick_buy()
    {
        if (PlayerPrefs.GetInt("GameScore") >= (7000 * playerNumber))
        {


            PlayerPrefs.SetInt("GameScore", PlayerPrefs.GetInt("GameScore") - (7000 * playerNumber));
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("unlock" + playerNumber, 1);

            //unlock0=1

            //unlock1=1
            //unlock2=1
        }
        else
        {
            print(" enough rupees");
            //  not_enough_cash.SetActive(true);
            //  Invoke("not_E_cash", 2f);
        }
    }
    public void not_E_cash()
    {
        //  not_enough_cash.SetActive(false);
    }
    public void selectPlayer()
    {
        PlayerPrefs.SetInt("selectedPlayer", playerNumber);
        menuFunction(2);
        print(PlayerPrefs.GetInt("selectedPlayer"));
    }
    //onclickLevelBtn-----------------------------------------------------------------------------------------------------------------------
    public void onclick_Level(int level_value)
    {
        lvl_no = level_value;
        loadButon.SetActive(true);
    }
    public void nextButn()
    {
         menuFunction(5);
        Invoke("LoadScene", 3f);
    }
   public void LoadScene()
    {
        SceneManager.LoadSceneAsync(lvl_no);
    }
   
  

}