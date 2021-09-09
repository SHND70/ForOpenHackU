using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class CreateItem : MonoBehaviour
{
    public GameObject[] Items;
    public Text text;
    public int Selector;

    // Start is called before the first frame update
    void Start()
    {
        Selector = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Create" + Items[Selector].name;
    }

    public void OnButtonClick(){
        Instantiate(Items[Selector],new Vector3(0,-2.5f,0),Quaternion.identity);
    }
}
