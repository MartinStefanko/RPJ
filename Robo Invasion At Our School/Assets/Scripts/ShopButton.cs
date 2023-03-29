using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    public int costOfHeart;
    public int heartToAdd;
    [SerializeField]
    private GameObject notificationNotEnoughMoney;

    public AudioSource buySound;
   

    HealthSystem hp;
    void Start()
    {
        hp = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
    }

    // Start is called before the first frame update
    public void Buy()
    {
        if (PlayerPrefs.GetInt("Money") >= costOfHeart)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - costOfHeart);
            int health = PlayerPrefs.GetInt("Health");
            PlayerPrefs.SetInt("Health", health + 1);
            hp.UpdateHealth();
            GameController.instance.UpdateMoneyTXT();
            if(!buySound.isPlaying)
            buySound.Play();
        }
        else
        {
            notificationNotEnoughMoney.SetActive(true);
            
        }
    }
   
    public void NotOff()
    {
        notificationNotEnoughMoney.SetActive(false);
    }
        
}
