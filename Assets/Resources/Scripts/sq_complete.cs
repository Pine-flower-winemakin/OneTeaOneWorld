using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sq_complete : MonoBehaviour
{
    // Start is called before the first frame update
    public int complete=0;
    //һ��ͼƬһ������
    private GameObject m_Image=null;
    private GameObject m_Text=null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("��ɶȣ�" + complete);
        if (m_Text != null && m_Image != null)
        {
            m_Text.GetComponent<Text>().text = (complete * 10).ToString() + "%";
            m_Image.GetComponent<Image>().fillAmount = complete / 10.0f;
        }   

        if (complete >= 10 && m_Text != null && m_Image != null)//�����
        {
            GameObject.Find("sq_director_2").SetActive(false);
            GameObject.Find("sq_circle_Image").SetActive(false);
            GameObject.Find("sq_circle_text").SetActive(false);

            // ��ȡ���������е�GameObject����
            GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();

            // �������е�GameObject����
            foreach (GameObject obj in allObjects)
            {
                // ���ö����Ƿ����ָ���������ѽ���
                if (obj.name == "MinMaxSlider" && !obj.activeSelf)
                {
                    // ��������
                    obj.SetActive(true);
                }
                if (obj.name == "sq_cloud" && !obj.activeSelf)
                {
                    // ��������
                    obj.SetActive(true);
                }
            }
/*            GameObject[] tea = GameObject.FindGameObjectsWithTag("sq_tea");
            foreach(GameObject t in tea)
            {
                for (int i = 0; i < t.childCount; i++)
                {
                    var child = father.GetChild(i).gameObject;
                    Debug.Log(child.name);
                }
            }*/
        }

        try
        {
            m_Image = GameObject.Find("sq_circle_Image");
            m_Text = GameObject.Find("sq_circle_text");
        }
        catch (Exception e)
        {
            Debug.Log(e + "δ�ҵ�sq_circle_Image �� sq_circle_text");
        }
    }
    public void setComplete(int complete)
    {
        this.complete = complete;
    }
}
