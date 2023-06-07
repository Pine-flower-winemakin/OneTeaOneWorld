using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class sq_loading : MonoBehaviour
{

    public Slider slider;  //������
    public Text Load_Data;  //������
    public Text WCD;//��ɶ��ı�
    public bool sq_start = false;
    private float complete = 0;
    public float speed = 0.6f;//ɹ���ٶ�
    GameObject parentObj;
    GameObject arrow1, arrow2, arrow3, arrow4,leadPOS;

    // Use this for initialization
    void Start()
    {
        slider.value = 0; //���ۼӵ��������������ֵ
        Load_Data.text = (int)(slider.value) + "%"; //��������ֵת����int���ͼ��ϰٷֱȸ����������
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
            Load_Data.text = (int)(slider.value) + "%"; //��������ֵת����int���ͼ��ϰٷֱȸ����������

            if (Math.Abs(complete - 100) < 1)
            {
                slider.value = 100;
                Load_Data.text = "ɹ�����";
                WCD.enabled = false;
                sq_start = false;
                GameObject empty = GameObject.Find("��ϲ���");
                // ��ȡ��һ���ű�������
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

