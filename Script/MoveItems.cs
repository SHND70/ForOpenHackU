using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItems : MonoBehaviour
{
    public Camera camera;
    public RaycastHit2D UIhits;
    public CreateRotateUI CreateRotateUI;
    // Start is called before the first frame update
    void Start()
    {
        CreateRotateUI = GameObject.Find("Canvas").GetComponent<CreateRotateUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            UIhits = Physics2D.Raycast(ray.origin,ray.direction, 100.0F);
        }

        if(UIhits.collider != null && Input.GetMouseButton(0) && CreateRotateUI.hitsObject == null ){
            UIhits.collider.transform.root.gameObject.transform.position = new Vector3((float)Camera.main.ScreenToWorldPoint(Input.mousePosition).x , (float)Camera.main.ScreenToWorldPoint(Input.mousePosition).y , 5);
        }
    }
}
