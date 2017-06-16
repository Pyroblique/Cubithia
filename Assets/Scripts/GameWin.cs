using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{

    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(new Rect(4 * scrW, 2 * scrH, 8 * scrW, scrH), "YOU WIN!!");

        
        // Play again
        if (GUI.Button(new Rect(5 * scrW, 5 * scrH, 6 * scrW, scrH), "Main Menu"))
        {
            SceneManager.LoadScene(0);
        }
        // Quit game
        if (GUI.Button(new Rect(5 * scrW, 6f * scrH, 6 * scrW, scrH), "Quit Game"))
        {
            Application.Quit();
        }
    }
}
