using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController instance = null;
    public GameObject shopMenu;
    public GameObject notification;
    public GameObject pauseMenu;
    public int money;
    public TextMeshProUGUI moneyTXT;
    public TextMeshProUGUI healthTXT;
    public TextMeshProUGUI ammoTXT;
    public TextMeshProUGUI NotificationTXT;
    Player player1;
    Shoot shoot1;
        public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != null)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        shoot1 = GameObject.FindGameObjectWithTag("Shoot").GetComponent<Shoot>();
        UpdateMoneyTXT();
        UpdateHealthTXT();
        UpdateammoTXT();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            PauseMenu();


        }
    }

    public void Shop()
    {
        Time.timeScale = 0;
        shopMenu.SetActive(true);
        notification.SetActive(false);

    }

    public void Resume()
    {
        Time.timeScale = 1;
        shopMenu.SetActive(false);
        notification.SetActive(true);
        

    }
    public void UpdateHealthTXT() {
        healthTXT.text = player1.health.ToString();

    }
    public void UpdateMoneyTXT()
    {
        moneyTXT.text = money.ToString() + "$";
    }
    public void UpdateammoTXT()
    {
        ammoTXT.text = shoot1.magSize.ToString();

    }
    public void NotifícationVisible()
    {
        notification.SetActive(true);
    }
    public void NotifícationNonVisible()
    {
        notification.SetActive(false);
    }

    public void PauseMenu()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);

        
    }
    public void PauseMenuResume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        pauseMenu.SetActive(false); Time.timeScale = 1;
    }





}
