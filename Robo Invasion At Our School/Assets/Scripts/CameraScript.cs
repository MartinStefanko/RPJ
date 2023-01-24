using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private Camera mainCamera;

    void FixedUpdate()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 midPoint = (mouseWorldPosition - player.position) / 5f;
        Vector3 midPointV3 = new Vector3(Mathf.Clamp(midPoint.x, -2.15f, 2.15f),
        Mathf.Clamp(midPoint.y, -1.25f, 1.25f), -10);

        transform.position = player.position + midPointV3;
     
    

        /* 
        if (midPoint.x < -0.3 || midPoint.x > 0.3 || midPoint.y < -0.3 || midPoint.y > 0.3)
            transform.position = player.position + midPointV3;
        else
           transform.position = new Vector3(player.position.x, player.position.y, -10);
        */

    } 
}
