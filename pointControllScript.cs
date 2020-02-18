using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointControllScript : MonoBehaviour
{
    public GameObject[] zombiePointsOn;
    public int zombiePointNumber;
    // Start is called before the first frame update
    void Start()
    {
        zombiePointNumber = Random.Range(0, zombiePointsOn.Length - 1);
    }

    // Update is called once per frame
    void LateUpdate()
    {

        for (int i = 0; i < zombiePointsOn.Length; i++)
        {
            if (i == zombiePointNumber)
            {
                zombiePointsOn[i].SetActive(true);
                zombiePointsOn[i].GetComponent<intantiateZombies>().enabled = true;

            }
            else
            {
                zombiePointsOn[i].GetComponent<intantiateZombies>().enabled = false;
                zombiePointsOn[i].SetActive(false);
            }


        }
    }
    public void pointChange()
    {
        zombiePointNumber = Random.Range(0, zombiePointsOn.Length - 1);
        intantiateZombies.oneTime = 0;
    }
}
