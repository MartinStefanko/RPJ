using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pointer : MonoBehaviour
{
    private Vector3 targetPosition;
    private RectTransform pointerRectTransform;
    [SerializeField]
    private Camera uiCamera;
    Player player1;

    private void Awake()
    {
        targetPosition = new Vector3(-10, 0);
        pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();
        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        Vector3 toPostion = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPostion - fromPosition).normalized;
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) % 360;
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);


        float borderSize = 100f;



    }
}
