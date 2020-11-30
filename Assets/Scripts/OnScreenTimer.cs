using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnScreenTimer : MonoBehaviour
{
    int currentTime;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = System.Convert.ToInt32(Time.time-startTime);
        GetComponent<TMPro.TextMeshProUGUI>().text = $"Time: {currentTime} seconds";
        PlayerPrefs.SetInt("finalTime", currentTime);
    }
}
