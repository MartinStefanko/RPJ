using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float timeOffset;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private float speed = 3f;

    private bool calc = false;

    private void Start()
    {
    }

    void FixedUpdate()
    {

        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 midPoint = (mouseWorldPosition - player.position) / 2.5f;
        Vector3 midPointV3 = new Vector3(Mathf.Clamp(midPoint.x, -5.80f, 5.80f),
                                         Mathf.Clamp(midPoint.y, -3.30f, 3.30f), -10);

        transform.position = player.position + midPointV3;
        
    } 
}
