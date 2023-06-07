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
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);//������Ļ����ת��Ϊһ������
        
        RaycastHit hit;

        //����Ϊ5
        //if(Physics.Raycast(ray, out hit, 5)) {
        //    var hitObj = hit.collider.gameObject;
        //    Debug.Log(hitObj);
        //}
        //�޾�������
        if (Physics.Raycast(ray, out hit))
        {
            var hitObj = hit.collider.gameObject;
            if (last == null)
            {
                last = hitObj;
            }
            if (last == hitObj) // ֻ�к��ϸ�����һ���ż�������
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