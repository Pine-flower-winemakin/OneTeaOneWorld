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
            Debug.Log("δ�ҵ�empty_1");
        }
        // ��ȡ��һ���ű�������
        sq_loading otherScript = empty.GetComponent<sq_loading>();

        // ��ȡ��һ���ű���public����
        float speed = otherScript.speed;
        if (other.tag == "sq_sun")
        {
            otherScript.setSpeed(speed + 2.0f);//�ӿ�ɹ���ٶ�
            this.gameObject.SetActive(false);//�����ƶ�
            Debug.Log("�����ƶ�");
        }
    }
   
}
