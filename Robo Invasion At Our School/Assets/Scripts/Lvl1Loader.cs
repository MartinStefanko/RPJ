using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1Loader : MonoBehaviour
{
    void Start()
    {
        foreach (Transform child in this.transform)
        {
            if(PlayerPrefs.GetInt("lvl1Completed") == 0)
            {
                if (child.gameObject.tag == "FriendlyNPC" || child.gameObject.tag == "Enemy")
                {
                    child.gameObject.SetActive(true);
                }
            }

            if(PlayerPrefs.GetInt("lvl1Completed") == 1)
            {
                if(child.gameObject.tag == "Door")
                    child.gameObject.SetActive(false);

                if (child.gameObject.tag == "OpenedDoor")
                    child.gameObject.SetActive(true);
            }
            
        }
    }
}
