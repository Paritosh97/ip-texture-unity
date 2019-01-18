using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShareScript : MonoBehaviour
{
    public RawImage displayImage;
    private string shareSubject, shareMessage;
    
    void Start()
    {
        displayImage.texture = CaptureImageScript.rawTexture;
    }

    public void OnShareButtonClick()
    {
        shareSubject = "Here's the captured image";
        shareMessage = "Here's the captured image." ;
        StartCoroutine(ShareImage());
    }

    private IEnumerator ShareImage()
    {
        yield return new WaitForEndOfFrame();

        new NativeShare().AddFile(CaptureImageScript.filePath).SetSubject(shareSubject).SetText(shareMessage).Share();

        // Share on WhatsApp only, if installed (Android only)
        if( NativeShare.TargetExists( "com.whatsapp" ) )
            new NativeShare().AddFile(CaptureImageScript.filePath).SetText( "Hello world!" ).SetTarget( "com.whatsapp" ).Share();
    }
}