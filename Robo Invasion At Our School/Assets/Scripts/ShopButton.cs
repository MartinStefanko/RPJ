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
    Player pl;

    void Start()
    {
        hp = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Start is called before the first frame update
    public void Buy()
    {
        if (GameController.instance.money >= costOfHeart && pl.health < 6)
        {
            GameController.instance.money -= costOfHeart;
            pl.health++;
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
