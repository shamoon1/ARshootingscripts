using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class gamePlayScripts : MonoBehaviour
{
    public GameObject[] gameitems,guns;
    public  float damage;
    public int number,endGame,totalbullets,bulletsInGun,zombieKill,killReward,killLevel;
    public GameObject cameras,reloadText,vfx;
    public float range, time;
    public bool gunFired;
    public Image power,cut;
    public Text coinsCollect,zombieCount;
    public AudioClip fire;
    public Text bulletCount;
    int my_Scene;


    public AudioSource fireSoundSource;
    // Start is called before the first frame update
    void Start()
    {
        killReward = 0;
           zombieKill = 0;
          my_Scene = SceneManager.GetActiveScene().buildIndex;
        time = 0.1f;
        reloadText.SetActive(false);
        fireSoundSource.enabled = false;
           number = 0;
        cut.gameObject.SetActive(false);
           endGame = 0;
        power.fillAmount = 1f;
           gunFired = false;
              //  number = 1;
              cameras = GameObject.FindGameObjectWithTag("MainCamera");
        range = 110000000f;
    }

    // Update is called once per frame
    void Update()
    {
        coinsCollect.text = killReward.ToString();
        zombieCount.text = zombieKill.ToString();

        bulletCount.text = bulletsInGun.ToString();
       
        //power 0 game end..............................................
        if (endGame == 0)
        {
            if (power.fillAmount <= 0)
            {
                gameFunction(3);
                endGame = 1;
            }
        }
     
        //gamescreens changer...........................................

        for (int i = 0; i < gameitems.Length; i++)
        {
            if (i == number)
            {
                gameitems[i].SetActive(true);
            }
            else
            {
                gameitems[i].SetActive(false);
            }

        }
        //gunss...........................................................
        for (int i = 0; i < guns.Length; i++)
        {
            if (i ==0)
            {
                guns[i].SetActive(true);
            }
            else
            {
                guns[i].SetActive(false);
            }

        }
        //shooting........................................................
        if (gunFired == true)
        {if (bulletsInGun > 0)
            {
                if (time >= 0)
                {
                    time -= Time.deltaTime;

                }
                else
                {
                    fireSoundSource.enabled = true;
                    time = 0.1f;
                    FindObjectOfType<characterAnimation>().particals.Play();
                    FindObjectOfType<characterAnimation>().smoke.Play();
                    FindObjectOfType<characterAnimation>().bulet.Play();
                    bulletsInGun -= 1;
                    RaycastHit hit;
                    if (Physics.Raycast(cameras.transform.position, cameras.transform.forward, out hit, range))
                    {
                        Debug.DrawRay(cameras.transform.position, cameras.transform.forward * 1000f, Color.red);
                        if (hit.transform.gameObject.tag == "zombie")
                        {
                            Instantiate(vfx, hit.point, hit.transform.rotation);

                             
                            hit.transform.gameObject.GetComponent<enemy>().power.fillAmount -= damage;
                            enemy.getHit = true;
                            print("zombieHits");
                        }

                    }
                }
            }
            else
            {
                fireSoundSource.enabled = false;
                reloadText.SetActive(true);
                Invoke("reloadOff", 1f);
            }

            // gunFired = false;
        }
        else
        {
            fireSoundSource.enabled = false;
        }
    }
    public void reloadOff()
    {
        reloadText.SetActive(false);
    }
    public void reloadGun()
    {
        FindObjectOfType<characterAnimation>().anim.CrossFade("reload");
          bulletsInGun = 20;
    }
    public void shoot()
    {
      
        gunFired = true;
    }
    public void shootfalse()
    {
    
        gunFired = false;
    }
    public void gameFunction(int vals)
    {
        number = vals;
        if (vals == 1)
        {
            enemy.paused = false;
        }
        else
        {
            enemy.paused = true;
        }
    }
    //restart function---------------------------------------------------------------------------------
    public void Restartonclick()
    {
        gameFunction(5);
        SceneManager.LoadScene(my_Scene, LoadSceneMode.Single);

    }
    //goto menu---------------------------------------------------------------------------------
    public void Menuclick()
    {
        gameFunction(5);

        SceneManager.LoadSceneAsync("SampleScene");

    }
    public void clearedLevel()
    {
        Invoke("gameCleared", 2f);
     
    }
    void gameCleared()
    {
        gameFunction(4);
    }

}
