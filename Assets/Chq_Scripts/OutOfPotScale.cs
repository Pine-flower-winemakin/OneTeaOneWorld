using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfPotScale : MonoBehaviour
{
    public Vector3 initV;
    public Vector3 nowV;
    public Vector3 replaceV;    //��ԭλ�ã���ָ����������ڳ�ʼλ��
    public float dis;

    GameObject pot;
    public Vector3 potV;        //����λ��
    // Start is called before the first frame update
    void Start()
    {
        initV = this.transform.position;
        replaceV = initV;
        pot = GameObject.Find("chq_pot");
        potV = pot.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        nowV = this.transform.position;
        dis = (nowV - potV).magnitude;    //�������
        if (dis > 1.0f)                       //����һ���ľ���
        {
            this.transform.position = replaceV; //��ԭλ��
        }
        Delay.DelayToInvoke(() => { }, 3f);     //ÿ��3����һ��
    }
}
