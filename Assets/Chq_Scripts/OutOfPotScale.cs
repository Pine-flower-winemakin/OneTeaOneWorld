using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfPotScale : MonoBehaviour
{
    public Vector3 initV;
    public Vector3 nowV;
    public Vector3 replaceV;    //复原位置，可指定，这里等于初始位置
    public float dis;

    GameObject pot;
    public Vector3 potV;        //锅的位置
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
        dis = (nowV - potV).magnitude;    //计算距离
        if (dis > 1.0f)                       //超过一定的距离
        {
            this.transform.position = replaceV; //复原位置
        }
        Delay.DelayToInvoke(() => { }, 3f);     //每隔3秒检测一次
    }
}
