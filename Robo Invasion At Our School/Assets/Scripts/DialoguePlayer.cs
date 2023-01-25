using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialoguePlayer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textComponent;
    [SerializeField]
    private float textSpeed;
    [SerializeField]
    private string[] lines;
    [SerializeField]
    private GameObject dialogueBox;

    private int index;

    public static bool dialogueOver = false;
    public static bool start;


    // Start is called before the first frame update
    /*
    void Start()
    {
        dialogueBox.SetActive(false);
        Invoke("StartDialogue", 1f);
    }
    */
    private void Start()
    {
        if (start)
            Invoke("StartDialogue", 1f);
        else
            dialogueBox.SetActive(false);
    }

    void StartDialogue()
    {
        textComponent.text = string.Empty;
        dialogueBox.SetActive(true);
        index = 0;
        StartCoroutine(TypeLine());
        
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        Invoke("DialogueOver", 1f);    
    }

    void DialogueOver()
    {
        dialogueBox.SetActive(false);
        dialogueOver = true;
    }
}