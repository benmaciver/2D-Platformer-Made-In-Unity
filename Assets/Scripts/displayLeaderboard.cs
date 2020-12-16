using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class displayLeaderboard : MonoBehaviour
{
    int heightDecrease = 50;
    void Start()
    {
        string leaderboard = Application.streamingAssetsPath + "/Text Files/" + "Leaderboard" + ".txt"; //gets leaderboard text fule
        string[] readText = File.ReadAllLines(leaderboard);//converts text file to string
        foreach (string line in readText)
        {
            GetComponent<TMPro.TextMeshProUGUI>().text += $"{line}\n";
            GetComponent<Transform>().position -= new Vector3(0f, 30f, 0f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
