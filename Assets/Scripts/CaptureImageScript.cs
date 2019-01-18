using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CaptureImageScript : MonoBehaviour {

    public RawImage rawImage;

    public GameObject receiver;

    public static string filePath;
    public static Texture rawTexture;

    void Start()
    {
        receiver.GetComponent<TextureSendReceive.TextureReceiver>().IP = ButtonScript.ip_addr;
    }

    public void imageCapture()
    {
        rawTexture = rawImage.texture;
        Texture2D image = rawImage.texture as Texture2D;
        byte[] bytes = image.EncodeToPNG();
        filePath = Application.persistentDataPath + "/image-" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";
        System.IO.File.WriteAllBytes(filePath, bytes);
        SceneManager.LoadScene("share");
    }
}
