using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()  
    {
        SceneManager.LoadScene("GameScene");
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("lvl1Completed", 0);
        PlayerPrefs.SetInt("lvl2Completed", 0);
        DialoguePlayer.dialogueOver = false;
        DialogueNPC.dialogueOver = false;
        SceneManager.LoadScene("Cutscene");
        DialoguePlayer.start = true;

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
