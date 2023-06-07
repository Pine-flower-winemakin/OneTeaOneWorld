using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sq_hitcloud : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        GameObject empty = GameObject.Find("empty_1");
        if (empty == null)
        {
            Debug.Log("未找到empty_1");
        }
        // 获取另一个脚本的引用
        sq_loading otherScript = empty.GetComponent<sq_loading>();

        // 获取另一个脚本的public参数
        float speed = otherScript.speed;
        if (other.tag == "sq_sun")
        {
            otherScript.setSpeed(speed + 2.0f);//加快晒青速度
            this.gameObject.SetActive(false);//消除云朵
            Debug.Log("击中云朵");
        }
    }
   
}
