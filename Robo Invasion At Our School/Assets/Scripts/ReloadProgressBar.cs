using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadProgressBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;    

    private float fillTime = 2.9f;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("start");
        Reset();
    }

    void Update()
    {
        slider.value = Time.time;
    }

    public void Reset()
    {
        //Debug.Log("resetting");
        slider.minValue = Time.time;
        slider.maxValue = Time.time + fillTime;
    }
    
}

    /*
    IEnumerator FillSliderOverTime()
    { 
        float elapsedTime = 0;

        while (elapsedTime < fillTime)
        {
            elapsedTime += Time.deltaTime;
            slider.value = Mathf.Lerp(0, 1, elapsedTime / fillTime);
            yield return null;
        }

        slider.value = 1;
        StopCoroutine(FillSliderOverTime());
    }
    */


