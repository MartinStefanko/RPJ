using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitLevel3Scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
    }
}
