using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfScale : MonoBehaviour
{
    public Vector3 initV;
    public Vector3 nowV;
    public Vector3 replaceV;    //��ԭλ�ã���ָ����������ڳ�ʼλ��
    public float dis;

    GameObject obj;
    public Vector3 objV;        //֧�ŵ�λ��
    // Start is called before the first frame update
    void Start()
    {
        initV = this.transform.position;
        replaceV = initV;
        obj = GameObject.Find("chanziCollider");
        objV = obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        nowV = this.transform.position;
        dis = (nowV - objV).magnitude;    //�������
        if (dis > 0.1f)                       //����һ���ľ���
        {
            this.transform.position = replaceV; //��ԭλ��
        }
        Delay.DelayToInvoke(() => { }, 1f);     //ÿ��1����һ��
    }
}
