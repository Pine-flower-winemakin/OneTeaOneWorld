using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sq_guide : MonoBehaviour

{
    GameObject parentObj;
    GameObject arrow1, arrow2, arrow3, arrow4;
    public void Start()
    {
        parentObj = GameObject.Find("sq_desk 1");
        arrow1 = parentObj.transform.Find("arrow1").gameObject;
        arrow2 = parentObj.transform.Find("arrow2").gameObject;
        arrow3 = parentObj.transform.Find("arrow3").gameObject;
        arrow4 = parentObj.transform.Find("arrow4").gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);//消除地面的提示点
        arrow1.SetActive(false);
        arrow2.SetActive(false);
        arrow3.SetActive(false);
        arrow4.SetActive(false);
    }
}
