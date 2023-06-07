using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sq_startBtnClick : MonoBehaviour
{
    public Button btn;
    public Canvas canvas_disappear;


    void Start()
    {
        // ���Ӽ����¼�
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void OnClick()
    {
        Debug.Log("Button Clicked. ClickHandler.");
        canvas_disappear.enabled = false;
        // ��ȡ���������е�GameObject����
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();

        // �������е�GameObject����
        foreach (GameObject obj in allObjects)
        {
            // ���ö����Ƿ����ָ���������ѽ���
            if (obj.name == "sq_director_2" && !obj.activeSelf)
            {
                // ��������
                obj.SetActive(true);
            }
            if (obj.name == "sq_circle_Image" && !obj.activeSelf)
            {
                // ��������
                obj.SetActive(true);
            }
            if (obj.name == "sq_circle_text" && !obj.activeSelf)
            {
                // ��������
                obj.SetActive(true);
            }

        }
    }
}
