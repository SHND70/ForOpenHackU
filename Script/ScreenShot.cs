using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
<<<<<<< HEAD
using System.Runtime.InteropServices;
=======
using System;
>>>>>>> origin/Inlab

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

<<<<<<< HEAD
    /*public int[,][] Data;
    public int[][] Col;*/

    public int[] Data;
=======
    public int[,][] Data;
    public int[][] Col;

    int LoopCountW = 0;
    int LoopCountH = 1;
>>>>>>> origin/Inlab

    public void Update()
    {
        printName = imageName.text;
    }

    public void OnClick() {
<<<<<<< HEAD
        //Data = new int[width,height][];
=======
        Data = new int[width,height][];
>>>>>>> origin/Inlab
       StartCoroutine(Capture(width,height));
    }

    public void Start() {
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

<<<<<<< HEAD
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
=======
        //RGBAを保存
        Col = new int[colors.Length][];
        for(int i=0;i<colors.Length;i++){
            Col[i] = new int[]{(int)(colors[i].r*255),(int)(colors[i].g*255),(int)(colors[i].b*255),(int)(colors[i].a*255)};
            //Debug.Log(Col[i][0]+","+Col[i][1]+","+Col[i][2]+","+Col[i][3]);
        }

        int C = 0;
        for(int w=0;w<width;w++){
            for(int h=0;h<height;h++)
            {
                //[幅,高さ] = [R,G,B,A]
                Data[w,h] = Col[C];
                //Debug.Log(Data[w,h][0]+","+Data[w,h][1]+","+Data[w,h][2]+","+Data[w,h][3]);
                C++;
            }
        }
        
        File.WriteAllBytes("Assets/ScreenShots/"+printName + ".png",saveTex.EncodeToPNG());
>>>>>>> origin/Inlab
        yield break;
    }
}
