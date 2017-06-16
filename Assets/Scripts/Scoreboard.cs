using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scoreboard : MonoBehaviour
{   
    public static int lives = 15;

    // Scoreboard
    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;


        GUI.Box(new Rect(scrW, 8f * scrH, scrW, 0.5f * scrH), "Lives");

        GUI.Box(new Rect(2 * scrW, 8f * scrH, scrW, 0.5f * scrH), lives.ToString());
    }

    // GAME OVER
    void Update()
    {
        if (lives <= 0)
        {
            SceneManager.LoadScene(2);
            lives = 15;
        }
    }
}

