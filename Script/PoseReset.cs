using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Core;

public class PoseReset : MonoBehaviour
{
    public GameObject RootOBJ;
    public CubismModel Models;
    //public CubismParameter[] Deformers;
    //public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        Models = RootOBJ.GetComponent<CubismModel>();
        /*Deformers = new CubismParameter[DeformerRoot.transform.childCount];
        for(int i = 0;i < DeformerRoot.transform.childCount;i++)
        {
            Deformers[i] = DeformerRoot.transform.GetChild(i).gameObject.GetComponent<CubismParameter>();
        }*/
    }

    public void OnButtonClick(){
        for(int i = 0;i<Models.Parameters.Length;i++){
            Models.Parameters[i].Value = 0;
            Debug.Log(Models.Parameters[i].Value);
        }
        /*for(int i = 0;i < Deformers.Length;i++)
        {
            Deformers[i].Value = 0;
            Debug.Log(Deformers[i].Value);
        } */  
    }
}
