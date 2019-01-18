using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    public Text ipText;

    public static string ip_addr;

    public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
        if(scene.Equals("WebcamModeReceive") || scene.Equals("VideoModeReceive"))
        {
            ip_addr = ipText.text;
        }
    }
}
