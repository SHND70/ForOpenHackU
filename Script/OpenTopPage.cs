using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTopPage : MonoBehaviour
{
    public string URL;
    
    public void OnButtonClick(){
        Application.OpenURL(URL);
    }
}
