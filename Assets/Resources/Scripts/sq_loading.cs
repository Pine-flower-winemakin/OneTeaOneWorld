using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class sq_loading : MonoBehaviour
{

    public Slider slider;  //进度条
    public Text Load_Data;  //加载数
    public Text WCD;//完成度文本
    public bool sq_start = false;
    private float complete = 0;
    public float speed = 0.6f;//晒青速度
    GameObject parentObj;
    GameObject arrow1, arrow2, arrow3, arrow4,leadPOS;

    // Use this for initialization
    void Start()
    {
        slider.value = 0; //将累加的数赋予进度条的值
        Load_Data.text = (int)(slider.value) + "%"; //将进度条值转化成int类型加上百分比赋予加载数。
        parentObj = GameObject.Find("sq_desk 1");
        arrow1 = parentObj.transform.Find("arrow1").gameObject;
        arrow2 = parentObj.transform.Find("arrow2").gameObject;
        arrow3 = parentObj.transform.Find("arrow3").gameObject;
        arrow4 = parentObj.transform.Find("arrow4").gameObject;
        leadPOS = parentObj.transform.Find("leadPOS").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (sq_start)
        {
            complete += Time.deltaTime*speed;
            slider.value = complete;
            Load_Data.text = (int)(slider.value) + "%"; //将进度条值转化成int类型加上百分比赋予加载数。

            if (Math.Abs(complete - 100) < 1)
            {
                slider.value = 100;
                Load_Data.text = "晒茶完成";
                WCD.enabled = false;
                sq_start = false;
                GameObject empty = GameObject.Find("恭喜完成");
                // 获取另一个脚本的引用
                AudioSource otherScript = empty.GetComponent<AudioSource>();
                otherScript.Play();
                arrow1.SetActive(true);
                arrow2.SetActive(true);
                arrow3.SetActive(true);
                arrow4.SetActive(true);
                leadPOS.SetActive(true);
            }
        }
    }

   public void setSpeed(float speed)
    {
        this.speed = speed;
    }
}

