using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    public static GameController instance = null;
    public GameObject shopMenu;
 
    public int money;
    public TextMeshProUGUI moneyTXT;
    public TextMeshProUGUI healthTXT;
    Player player1;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if(instance!= null)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        UpdateMoneyTXT();
        UpdateHealthTXT();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Shop()
    {
        Time.timeScale = 0;
        shopMenu.SetActive(true);
        
       
    }

    public void Resume()
    {
        Time.timeScale = 1;
        shopMenu.SetActive(false);
        
   
    }
    public void UpdateHealthTXT() {
        healthTXT.text = player1.health.ToString();
        
    }
    public void UpdateMoneyTXT()
    {
        moneyTXT.text = money.ToString() + "$";
    }


}
