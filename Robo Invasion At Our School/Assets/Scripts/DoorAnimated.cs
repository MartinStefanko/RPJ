using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimated : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    private AudioSource doorAudio;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void DoorOpen()
    {
        if(!doorAudio.isPlaying)
            doorAudio.Play();
        animator.SetBool("Open", true);
    }
    
    static public void test()
    {
        
    }
}
