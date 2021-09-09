using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Live2D.Cubism.Core;
using Live2D.Cubism.Framework.Raycasting;

public class CreateRotateUI : MonoBehaviour
{
    //UI操作
    public GameObject RotateUI;
    GameObject Child;
    public Camera camera;

    public CubismRaycaster raycaster;
    public CubismRaycastHit[] results = new CubismRaycastHit[4];
    public int hitCount;

    //検索するボーン群
    public GameObject ParmetersObject;
    public GameObject[] SearchObject;

    //選択されたボーン
    public GameObject hitsObject;

    //UIたち
    public GameObject[] UIs;
    public RaycastHit[] UIhits;

    // Start is called before the first frame update
    void Start()
    {
        SearchObject = new GameObject[ParmetersObject.transform.childCount];

        for (int i = 0; i < ParmetersObject.transform.childCount; i++)
        {
            SearchObject[i] = ParmetersObject.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0)){
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            hitCount =  raycaster.Raycast(ray, results);
            UIhits = Physics.RaycastAll(ray, 100.0F);

            //rayの当たった数だけ
            for(int i = 0; i < hitCount; i++){
                //Parameterを全探索
                for(int j = 0; j < SearchObject.Length; j++){
                    Debug.Log(SearchObject[j]+","+results[i].Drawable.gameObject.GetComponent<RerateParas>().Para);
                    //もしIDが一緒なら
                    if(SearchObject[j] == results[i].Drawable.gameObject.GetComponent<RerateParas>().Para)
                    
                    {
                        hitsObject = SearchObject[j];
                        break;
                    }
                }
            }
            
            Debug.Log(UIhits.Length);

            //操作バーの生成
            if(hitCount != 0 && EventSystem.current.IsPointerOverGameObject() == false){      
                Child = (GameObject)Instantiate (RotateUI, Input.mousePosition, Quaternion.identity);
                UIs = new GameObject[this.transform.childCount];

                for (int i = 0; i < this.transform.childCount; i++)
                {   
                    if(Child.name == this.transform.GetChild(i).gameObject.name){
                        Destroy(this.transform.GetChild(i).gameObject);
                    }
                }
                
	    	    Child.transform.parent = this.transform;
            }else if(hitCount == 0 && hitsObject != null && EventSystem.current.IsPointerOverGameObject() == false){
                Destroy(this.transform.Find("setRad(Clone)").gameObject);
                hitsObject = null;
            }

        }
    }
}
