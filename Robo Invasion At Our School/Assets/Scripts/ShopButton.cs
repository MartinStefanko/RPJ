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
    void Start()
    {
       
        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Start is called before the first frame update
    public void Buy()
    {
        if (GameController.instance.money >= costOfHeart)
        {
            GameController.instance.money -= costOfHeart;
            player1.health += 1;
            GameController.instance.UpdateMoneyTXT();
            GameController.instance.UpdateHealthTXT();
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
