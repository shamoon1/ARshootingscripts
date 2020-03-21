using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intantiateZombies : MonoBehaviour
{
    public GameObject[] zombie;
    public int zombiesNum;
    public static int oneTime;
    // Start is called before the first frame update
    void Start()
    {
        zombiesNum = Random.Range(0, zombie.Length - 1);
      oneTime = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (oneTime == 0)
        {


            for (int i = 0; i < zombie.Length; i++)
            {
                if (i == zombiesNum)
                {
                    Instantiate(zombie[i], this.transform.position, this.transform.rotation);
                    oneTime = 1;
                }


            }
        }
    }
   
}
