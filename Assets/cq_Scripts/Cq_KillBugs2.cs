using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Cq_KillBugs2 : MonoBehaviour
{
    public GameObject detectObject;
    public int arrayLength = 3;
    public GameObject[] Bugs;
    public int killBugsNum;
    public Canvas canvas_disappear;
    public Canvas canvas_appear;
    public AudioSource audioSource;  // 音效播放
                                     //*************输入设别**************************
    InputDevice leftHandController;
    InputDevice rightHandController;
    InputDevice headController;
    bool triggerValue;
    public AudioClip audioClip;
    //提供状态字典独立记录各个feature的状态
    Dictionary<string, bool> stateDic;
    // Start is called before the first frame update

    private void Init()
    {
        // 获取对应的InputDevice对象
        if (!leftHandController.isValid)
        {
            leftHandController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        }
        if (!rightHandController.isValid)
        {
            rightHandController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        }
        if (!headController.isValid)
        {
            headController = InputDevices.GetDeviceAtXRNode(XRNode.Head);
        }

        stateDic = new Dictionary<string, bool>();

    }

    private void Awake()
    {
        //获得AudioSource组件
        audioSource = gameObject.GetComponent<AudioSource>();
        //设置不一开始就播放音效
        audioSource.playOnAwake = false;
    }
    void Start()
    {
        Init();
        killBugsNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 这里应该再加一个条件：目前拿着的物体是killBug杀虫剂 留在测试的时候加 左手按下trigger键
        if (leftHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            //Debug.Log("按下了空格");
            Collider[] collider = Physics.OverlapBox(detectObject.transform.position, new Vector3(1, 1, 1)); // 创建碰撞进行范围检测
            Debug.Log("创建了碰撞体");
            for (int i = 0; i < collider.Length; i++)
            {
                //Debug.Log("正在检测"+i);
                //Debug.Log(collider[i].gameObject.name);
                if (collider[i].gameObject.name == "Cq_killBug") // 检测到的碰撞的物体是killBug杀虫剂的话
                {
                    Debug.Log("杀死一只虫子" + Bugs[killBugsNum].name);
                    Debug.Log("播放音乐");
                    audioSource.Play();
                    Bugs[killBugsNum].SetActive(false);
                    // Bugs[killBugsNum].GetComponent<Cq_FadeInOut>().FadeOut();
                    killBugsNum++;
                    break;
                }
            }

        }

        // 显现下一个panel
        if (killBugsNum == arrayLength)
        {
            audioSource.clip = audioClip;
            canvas_appear.gameObject.SetActive(true);
            canvas_disappear.gameObject.SetActive(false);
            audioSource.Play();
        }
    }
}