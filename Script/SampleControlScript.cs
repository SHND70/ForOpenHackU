using Live2D.Cubism.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleControlScript : MonoBehaviour
{
    public CubismParameter CP;
    public float InputValue;
    // Start is called before the first frame update
    void Start()
    {
        CP = GetComponent<CubismParameter>();
        InputValue = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(CP.MinimumValue < InputValue && InputValue < CP.MaximumValue)
        {
            CP.Value = InputValue;
        }
        else if(InputValue <= CP.MinimumValue)
        {
            InputValue = CP.MinimumValue;
        }
        else if(InputValue >= CP.MaximumValue)
        {
            InputValue = CP.MaximumValue;
        }
    }
}
