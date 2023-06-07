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
        // 增加监听事件
        btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void OnClick()
    {
        Debug.Log("Button Clicked. ClickHandler.");
        canvas_disappear.enabled = false;
        // 获取场景中所有的GameObject对象
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();

        // 遍历所有的GameObject对象
        foreach (GameObject obj in allObjects)
        {
            // 检查该对象是否具有指定名称且已禁用
            if (obj.name == "sq_director_2" && !obj.activeSelf)
            {
                // 将其启用
                obj.SetActive(true);
            }
            if (obj.name == "sq_circle_Image" && !obj.activeSelf)
            {
                // 将其启用
                obj.SetActive(true);
            }
            if (obj.name == "sq_circle_text" && !obj.activeSelf)
            {
                // 将其启用
                obj.SetActive(true);
            }

        }
    }
}
