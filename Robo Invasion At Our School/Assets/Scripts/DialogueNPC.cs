using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueNPC : MonoBehaviour
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


    void Awake()
    {
        StartDialogue();
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
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        Invoke("DialogueOver", 1f);
    }

    void DialogueOver()
    {
        Destroy(dialogueBox);
        dialogueOver = true;
    }
}
