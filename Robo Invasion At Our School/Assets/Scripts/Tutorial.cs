using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private Transform camera;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject quests;
    [SerializeField]
    private GameObject magazine;
    [SerializeField]
    private GameObject fps;
    [SerializeField]
    private GameObject pointer;

    [SerializeField]
    private GameObject dialogueBoxNPC;
    [SerializeField]
    private GameObject dialogueBoxNPC2;

    [SerializeField]
    private GameObject robot;


    public static bool cameraSet = false;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        quests.SetActive(false);
        magazine.SetActive(false);
        fps.SetActive(false);
        pointer.SetActive(false);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move camera to certain position
        if (camera.position.y != 0.9999985f && DialoguePlayer.dialogueOver)
            camera.position += new Vector3(0.05f, 0.10f, 0);
        if(camera.position.y == 0.9999985f && dialogueBoxNPC != null)
            dialogueBoxNPC.SetActive(true);

        if (DialogueNPC.dialogueOver)
        {
            panel.SetActive(true);
            magazine.SetActive(true);
            fps.SetActive(true);
        }

        if (dialogueBoxNPC2 != null && robot == null && DialogueHandler.startPlayerDialogue)
            dialogueBoxNPC2.SetActive(true);

        if (DialogueNPC2.dialogueOver)
        {
            quests.SetActive(true);
            if(!Level1.playerOnLvl)
                pointer.SetActive(true);
        }


    }
}
