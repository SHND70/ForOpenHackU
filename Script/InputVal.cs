using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputVal : MonoBehaviour
{
    public BorneController BC;
    //public bool Changing = false;
    // Start is called before the first frame update

    public void LockInput(InputField  input)
    {
        BC.slider.value = int.Parse(input.text);
        BC.CP.Value = BC.slider.value;
        //Changing = false;
    }

}
