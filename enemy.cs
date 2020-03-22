using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public Image power;
    int DestroyThis, stop,changeSound;
    float time;
    public Animation anime;
    public Vector3 target;
    public GameObject cam;
   public bool moveTo = false;
    public bool death;
    public static bool getHit,paused;
    public AudioSource amobieVoice;
    public AudioClip[] zombieClips;
    // Start is called before the first frame update
    void Start()
    {
        changeSound = 0;
    paused = false;
        time = 1;
           death = false;
           getHit = false;
           anime = this.GetComponent<Animation>();
           cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (DestroyThis == 0)
        {

            if (power.fillAmount <= 0)
            {
                anime.CrossFade("death");
                death = true;
              
               FindObjectOfType<gamePlayScripts>().killReward += 20;
                FindObjectOfType<gamePlayScripts>().zombieKill += 1;
                //gameCleared..............................................................
                if (FindObjectOfType<gamePlayScripts>().zombieKill == FindObjectOfType<gamePlayScripts>().killLevel)
                {
                    PlayerPrefs.SetInt("GameScore", PlayerPrefs.GetInt("GameScore") + (FindObjectOfType<gamePlayScripts>().killReward));
                    FindObjectOfType<gamePlayScripts>().gunFired = false;
                    FindObjectOfType<gamePlayScripts>().clearedLevel();

                }
                else
                {
                    FindObjectOfType<pointControllScript>().pointChange();
                }
               
                Invoke("destroyZombie", 3f);
                DestroyThis = 1;
            }


        }
        if (death == true)
        {


        }
        else
        {

            if (getHit == true)
            {
                anime.CrossFade("getHit");
                Invoke("getItFalse", 0.5f);
            }
            else
            {

                if (paused == false)
                {



                    if (moveTo && (Vector3.Distance(this.transform.position, target) < 0.5f))
                    {
                        if (time >= 0)
                        {
                            time -= Time.deltaTime;
                        }
                        else
                        {
                            FindObjectOfType<gamePlayScripts>().cut.gameObject.SetActive(true);
                            FindObjectOfType<gamePlayScripts>().power.fillAmount -= 0.1f;
                            Invoke("cutOff", 0.5f);
                            time = 1.3f;
                        }
                        Goto();
                        anime.CrossFade("attack");

                    }
                    else
                    {
                        if (changeSound == 0)
                        {
                            Invoke("PlaySoundZombie", 3f);
                            changeSound = 1;
                        }
                      
                        Goto();
                        this.transform.position = Vector3.MoveTowards(this.transform.position, target, 0.5f * Time.deltaTime);
                    }
                }
                else
                {
                    anime.CrossFade("idle");
                }
            }
        }

       

    }
    void PlaySoundZombie()
    {
        for (int i = 0; i < zombieClips.Length; i++)
        {
            if (i == Random.Range(0, zombieClips.Length - 1))
            {
                amobieVoice.PlayOneShot(zombieClips[i], 1f);
            }
        }
        changeSound = 0;
    }
    void cutOff()
    {
        FindObjectOfType<gamePlayScripts>().cut.gameObject.SetActive(false);
    }
    void getItFalse()
    {
        getHit = false;
    }
    void destroyZombie()
    {
        Destroy(this.gameObject);
    }
      public void Goto()
    { 
        Vector3 pos;
        anime.CrossFade("walk");
        pos.y = FindObjectOfType<GoogleARCore.Examples.HelloAR.HelloARController>().anything.y;
       // pos.y = 0;


        pos.z = cam.transform.position.z;
        pos.x = cam.transform.position.x;
        target = pos;
       // cube.transform.position = target;
        transform.LookAt(pos);
        moveTo = true;
    } 

}
