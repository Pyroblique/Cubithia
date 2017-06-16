using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    // Menu
    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
        // Play game
        if (GUI.Button(new Rect(5 * scrW, 4 * scrH, 6 * scrW, scrH), "Play"))
        {
            SceneManager.LoadScene(1);
        }
        // Quit game
        if (GUI.Button(new Rect(6 * scrW, 5.75f * scrH, 4 * scrW, 0.5f * scrH), "Quit"))
        {
            Application.Quit();
        }
    }
}
