using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class FirebaseScript : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Firestore();

    [DllImport("__Internal")]
    private static extern void Check();

    [DllImport("__Internal")]
    private static extern void Reg();

    [DllImport("__Internal")]
    private static extern void Login();

    [DllImport("__Internal")]
    private static extern void Logout();

    [DllImport("__Internal")]
    private static extern void Get(string col, string doc);

    [DllImport("__Internal")]
    private static extern void Get2(string col, string doc);

    [DllImport("__Internal")]
    private static extern void SetInt(string col, string doc, string key, int val);

    [DllImport("__Internal")]
    private static extern void SetStr(string col, string doc, string key, string val);

    [DllImport("__Internal")]
    private static extern void StrTest(string s);

    [DllImport("__Internal")]
    private static extern void SetArray(string col, string doc, string key, int[] a, int l);

    // Start is called before the first frame update
    void Start()
    {
        string col = "users", doc = "testdoc";

        Firestore();
        Check();
        //Reg();
        Login();
        Get(col, doc);

        doc = "adder";
        string key = "key", val = "value";
        SetStr(col, doc, key, val);

        doc = "ArrayAdd";
        key = "arr";
        int[] refIntArray = new int[3];
        SetArray(col, doc, key, refIntArray, refIntArray.Length);
        string str = "string test";
        StrTest(str);
    }

    void OnDestroy()
    {
        Logout();
    }

    // Update is called once per frame
    public void UpdateText(string newText)
    {
        Text text = GameObject.Find("Text").GetComponent<Text>();
        text.text = newText;
    }
}

