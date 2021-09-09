﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Live2D.Cubism.Core;

public class BorneController : MonoBehaviour
{
    public Slider slider;
    private GameObject ControlObj; 
    public CubismParameter CP;
    public bool Dodestroy;
    public InputField inputField;

    //public InputVal iV; 

    // Start is called before the first frame update
    void Start()
    {
        ControlObj = this.gameObject.GetComponentInParent<CreateRotateUI>().hitsObject;
        CP = ControlObj.GetComponent<CubismParameter>();
        slider = this.gameObject.GetComponent<Slider>();
        //iV = GetComponentInChildren<InputVal>();
        slider.maxValue = CP.MaximumValue;
        slider.minValue = CP.MinimumValue;
        slider.value = CP.Value;
        inputField.text = slider.value.ToString();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //if(!iV.Changing){
            CP.Value  = slider.value;
            inputField.text = slider.value.ToString();
        //}
            
    }
}
