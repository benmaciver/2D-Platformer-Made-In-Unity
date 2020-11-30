using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayTime : MonoBehaviour
{
    int timeTaken;
    // Start is called before the first frame update
    void Start()
    {
        timeTaken = PlayerPrefs.GetInt("finalTime");
        GetComponent<TMPro.TextMeshProUGUI>().text = $"Level Complete!\nYou took: {timeTaken} seconds";
    }
}

