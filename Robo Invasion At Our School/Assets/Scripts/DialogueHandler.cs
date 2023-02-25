using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueBox;

    public static bool startPlayerDialogue;

    // Start is called before the first frame update
    void Start()
    {
        if (startPlayerDialogue == true)
        {
            Invoke("StartPlayerDialogue",1f);
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartPlayerDialogue()
    {
        dialogueBox.SetActive(true);
    }
}
