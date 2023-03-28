using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueNPC2 : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textComponent;
    [SerializeField]
    private float textSpeed;
    [SerializeField]
    private string[] lines;
    [SerializeField]
    private GameObject dialogueBox;
    [SerializeField]
    private GameObject quests;
    [SerializeField]
    private GameObject pointer;



    private int index;

    public static bool dialogueOver = false;


    // Start is called before the first frame update
    void Awake()
    {
        StartDialogue();
        
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("lvl1Completed") != 0)
        {
            Debug.Log("dialogue true");
            dialogueOver = true;

        }
    }

    void StartDialogue()
    {
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
        quests.SetActive(true);
        pointer.SetActive(true);
    }
}
