using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelector : MonoBehaviour
{
    public CreateItem createItem;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClickRight(){
        if(createItem.Selector<createItem.Items.Length-1){
            createItem.Selector = createItem.Selector + 1;
        }else{
            createItem.Selector = 0;
        }
    }

    public void OnButtonClickLeft(){
        if(createItem.Selector > 0){
            createItem.Selector = createItem.Selector - 1;
        }else{
            createItem.Selector = createItem.Items.Length - 1;
        }
    }
}
