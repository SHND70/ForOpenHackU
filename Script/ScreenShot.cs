using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScreenShot : MonoBehaviour
{
    // Start is called before the first frame update

    public string printName;

    public Text imageName;
    
    public int width;
    public int height;

    public void Update()
    {
        printName = imageName.text;
    }

    public void OnClick() {
       StartCoroutine(Capture(width,height));
    }

    public virtual IEnumerator Capture(int width,int height)
    {
        yield return new WaitForEndOfFrame();

        Texture2D tex = ScreenCapture.CaptureScreenshotAsTexture();
        int x = (tex.width - width)/2;
        int y = (tex.height - height)/2;
        Color[] colors = tex.GetPixels(x,y,width,height);
        Texture2D saveTex = new Texture2D(width,height,TextureFormat.ARGB32,false);
        saveTex.SetPixels(colors);
        File.WriteAllBytes("Assets/ScreenShots/"+printName + ".png",saveTex.EncodeToPNG());
        yield break;
    }
}
