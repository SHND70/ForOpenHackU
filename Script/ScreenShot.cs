using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class ScreenShot : MonoBehaviour
{
    // Start is called before the first frame update

    public string printName;

    public Text imageName;
    
    public int width;
    public int height;

    public int[,][] Data;
    public int[][] Col;

    int LoopCountW = 0;
    int LoopCountH = 1;

    public void Update()
    {
        printName = imageName.text;
    }

    public void OnClick() {
        Data = new int[width,height][];
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
        yield break;
    }
}
