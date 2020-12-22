using System.Linq;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class displayTime : MonoBehaviour
{
    // string variable that stores the contents of  leaderboard.txt
    string leaderboard;
    //int value for the players toime
    int timeTaken;
    // Start is called before the first frame update
    void Start()
    {

        //gets leaderboard text file
        leaderboard= Application.streamingAssetsPath + "/Text Files/" + "Leaderboard" + ".txt";
        //gets the time taken
        timeTaken = PlayerPrefs.GetInt("finalTime");
        //updates leaderboard with new time
        updateLeaderboard(timeTaken,leaderboard);
        //displays it on screen
        GetComponent<TMPro.TextMeshProUGUI>().text = $"Level Complete!\nYou took: {timeTaken} seconds";
    }

    void updateLeaderboard( int timeSubmission, string textFile)
    {
        // creates streamwritter oject (from System.IO namespace)
        //this allows for writing to text files 
        //submits the time taken to the text file

        bool repeat = false;
        string[] readText = File.ReadAllLines(textFile);//converts text file to string
        foreach (string line in readText) //checks for duplicates
        {
            if (line == $"{timeSubmission} seconds")
            {
                repeat = true;//if duplicates found repeat = true
            }
        }
        if (repeat != true)//only writes to text file if the time isn't a duplicate
        {
            StreamWriter sw = new StreamWriter(textFile, true); //true tells it that we are appending (adding) to the file
            string newLine = $"{timeSubmission} seconds";
            sw.WriteLine(newLine);
            sw.Close();

        }
        //this solves problem of new time being submitted after leaving the leaderboard screen and returning to previous menu


    }
}
