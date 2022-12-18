using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform player;
   
    [SerializeField]
    private float timeOffset;


    void FixedUpdate()
    {
        // Camera's current position
        Vector3 startPos = transform.position;

        // Player's current position
        Vector3 endPos = player.transform.position;

        endPos.z = -10;

        // Camera slowly follows player
        transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);
    }
}
