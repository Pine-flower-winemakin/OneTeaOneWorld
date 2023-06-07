using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sq_targetTrigger : MonoBehaviour
{
    private bool isComplete = false;
    private void OnTriggerEnter(Collider other)
    {
        GameObject empty = GameObject.Find("complete");
        // 获取另一个脚本的引用
        sq_complete  otherScript = empty.GetComponent<sq_complete>();

        // 获取另一个脚本的public参数
        int complete = otherScript.complete;
        if (other.tag == "sq_tea"&& !isComplete)
        {
            otherScript.setComplete(complete + 1);
            isComplete = true;         
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject empty = GameObject.Find("complete");
        // 获取另一个脚本的引用
        sq_complete otherScript = empty.GetComponent<sq_complete>();

        // 获取另一个脚本的public参数
        int complete = otherScript.complete;
        if (other.tag == "sq_tea" && isComplete)
        {
            otherScript.setComplete(complete - 1);
            isComplete = false;
        }
    }
}
