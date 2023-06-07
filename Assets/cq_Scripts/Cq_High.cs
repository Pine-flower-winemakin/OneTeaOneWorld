using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cq_High : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject last = null;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);//鼠标的屏幕坐标转化为一条射线
        
        RaycastHit hit;

        //距离为5
        //if(Physics.Raycast(ray, out hit, 5)) {
        //    var hitObj = hit.collider.gameObject;
        //    Debug.Log(hitObj);
        //}
        //无距离限制
        if (Physics.Raycast(ray, out hit))
        {
            var hitObj = hit.collider.gameObject;
            if (last == null)
            {
                last = hitObj;
            }
            if (last == hitObj) // 只有和上个物体一样才继续高亮
            {
                if (hitObj.GetComponent<Cq_HighlightableObject>())
                {
                    hitObj.GetComponent<Cq_HighlightableObject>().FlashingOn(Color.red, Color.yellow, 0.8f);
                    Debug.Log(hitObj);
                }
            }
            else
            {
                if (last.GetComponent<Cq_HighlightableObject>())
                {
                    last.GetComponent<Cq_HighlightableObject>().FlashingOff();
                }
                last = null;
            }
        }
        else
        {
            if (last!= null && last.GetComponent<Cq_HighlightableObject>())
            {
                last.GetComponent<Cq_HighlightableObject>().FlashingOff();
            }
            last = null;
        }
    }
}