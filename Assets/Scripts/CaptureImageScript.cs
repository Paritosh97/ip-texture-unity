using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CaptureImageScript : MonoBehaviour {

    public RawImage rawImage;

    public static string filename;

    public static string ImageName(int width, int height)
    {
        return string.Format("{0}/image_{1}x{2}_{3}.png",
                             Application.dataPath,
                             width, height,
                             System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

    public void imageCapture()
    {
        Texture2D image = rawImage.texture as Texture2D;
        byte[] bytes = image.EncodeToPNG();
        filename = ImageName(image.width, image.height);
        System.IO.File.WriteAllBytes(filename, bytes);
        SceneManager.LoadScene("picshare");
    }
}
