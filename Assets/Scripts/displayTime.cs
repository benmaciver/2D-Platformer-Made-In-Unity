using System.Linq;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class displayTime : MonoBehaviour
{
    // Coooridnates for where the times will be displayed on screen
    Vector3 textLocation;
    //prefab for the text lines created in the unity editor
    public GameObject textObject;
    // string variable that stores the contents of  leaderboard.txt
    string leaderboard;

    int timeTaken;
    // Start is called before the first frame update
    void Start()
    {

        //gets leaderboard text file
        leaderboard= Application.streamingAssetsPath + "/Text Files/" + "Leaderboard" + ".txt";
        //gets the time taken
        timeTaken = PlayerPrefs.GetInt("finalTime");
        //updates leaderboard with new time
        updateLeaderboardTextFile(timeTaken,leaderboard);
        
        //displays it on screen
        GetComponent<TMPro.TextMeshProUGUI>().text = $"Level Complete!\nYou took: {timeTaken} seconds";
    }

    void updateLeaderboardTextFile( int timeSubmission, string textFile)
    {
        //print($"Time taken:{timeSubmission}");
        // creates streamwritter oject (from System.IO namespace)
        //this allows for writing to text files 
        StreamWriter sw = new StreamWriter(textFile, true); //true tells it that we are appending (adding) to the file
        string newLine = $"{timeSubmission} seconds";
        sw.WriteLine(newLine);
        sw.Close();


    }
}
