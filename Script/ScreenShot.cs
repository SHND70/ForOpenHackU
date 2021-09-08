using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.InteropServices;

public class ScreenShot : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Firestore();

    [DllImport("__Internal")]
    private static extern void Login();

    [DllImport("__Internal")]
    private static extern void UpPic(string name, byte[] bytes, int len);

    // Start is called before the first frame update

    public string printName;

    public Text imageName;
    
    public int width;
    public int height;

    /*public int[,][] Data;
    public int[][] Col;*/

    public int[] Data;

    public void Update()
    {
        printName = imageName.text;
    }

    public void OnClick() {
        //Data = new int[width,height][];
       StartCoroutine(Capture(width,height));
    }

    public void Awake() {
        Firestore();
        Login();
    }

    public virtual IEnumerator Capture(int width,int height)
    {
        yield return new WaitForEndOfFrame();

        Texture2D tex = ScreenCapture.CaptureScreenshotAsTexture();
        int x = (tex.width - width)/2;
        int y = (tex.height - height)/2 + 100;
        Color[] colors = tex.GetPixels(x,y,width,height);
        Texture2D saveTex = new Texture2D(width,height/*,TextureFormat.RGB32,false*/);
        saveTex.SetPixels(colors);

        string NullStr = null, EmptyStr = string.Empty, BlankStr = "";
        if (printName != NullStr && printName != EmptyStr && printName != BlankStr)
        {
            /*
            byte[] refIntArray = new byte[colors.Length * 3];
            for (int i = 0; i < colors.Length; i++)
            {
                refIntArray[3 * i + 0] = (byte)(colors[i].r * 255);
                refIntArray[3 * i + 1] = (byte)(colors[i].g * 255);
                refIntArray[3 * i + 2] = (byte)(colors[i].b * 255);
            }
            */
            byte[] refIntArray = saveTex.EncodeToPNG();
            UpPic(printName, refIntArray, refIntArray.Length);
        }
        //File.WriteAllBytes("Assets/ScreenShots/"+printName + ".png",saveTex.EncodeToPNG());
        yield break;
    }
}
