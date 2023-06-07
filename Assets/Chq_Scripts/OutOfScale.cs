using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfScale : MonoBehaviour
{
    public Vector3 initV;
    public Vector3 nowV;
    public Vector3 replaceV;    //复原位置，可指定，这里等于初始位置
    public float dis;

    GameObject obj;
    public Vector3 objV;        //支撑的位置
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
        dis = (nowV - objV).magnitude;    //计算距离
        if (dis > 0.1f)                       //超过一定的距离
        {
            this.transform.position = replaceV; //复原位置
        }
        Delay.DelayToInvoke(() => { }, 1f);     //每隔1秒检测一次
    }
}
