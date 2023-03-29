using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject notification;

    public void LoadGame()
    {
        if (PlayerPrefs.GetInt("lvl1Completed") == 0 )
        {
            notification.SetActive(true);
        }
        else { 
        DialoguePlayer.dialogueOver = true;
        DialogueNPC.dialogueOver = true;
        SceneManager.LoadScene("GameScene");
        DialogueHandler.startPlayerDialogue = false;
        }
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("lvl1Completed", 0);
        PlayerPrefs.SetInt("lvl2Completed", 0);
        PlayerPrefs.SetInt("Money", 100);
        DialoguePlayer.dialogueOver = false;
        DialogueNPC.dialogueOver = false;
        SceneManager.LoadScene("Cutscene");
        DialogueHandler.startPlayerDialogue = true;

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
