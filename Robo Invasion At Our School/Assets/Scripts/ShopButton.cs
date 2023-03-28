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
   

    Player player1;
    HealthSystem hp;
    void Start()
    {
        hp = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Start is called before the first frame update
    public void Buy()
    {
        if (GameController.instance.money >= costOfHeart)
        {
            GameController.instance.money -= costOfHeart;
            player1.health += 1;
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
