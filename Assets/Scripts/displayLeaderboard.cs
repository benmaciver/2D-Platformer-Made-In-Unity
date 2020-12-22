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
        List<string> leaderboard = new List<string>();
        string textFile = Application.streamingAssetsPath + "/Text Files/" + "Leaderboard" + ".txt"; //gets leaderboard text fule
        string[] readText = File.ReadAllLines(textFile);//converts text file to string array
        foreach (string line in readText)
        {
            leaderboard.Add(line);
        }
        leaderboard.Sort();
        foreach (string line in leaderboard)
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
