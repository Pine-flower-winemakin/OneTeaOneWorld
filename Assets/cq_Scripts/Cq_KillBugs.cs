using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cq_KillBugs : MonoBehaviour
{
    public GameObject detectObject;
    public int arrayLength = 3;
    public GameObject[] Bugs;
    public int killBugsNum;
    public Canvas canvas_disappear;
    public Canvas canvas_appear;
    public AudioSource audioSource;  // 音效播放
    private bool flag;
    public AudioClip audioClip;
    // Start is called before the first frame update

    private void Awake()
    {
        //获得AudioSource组件
        audioSource = gameObject.GetComponent<AudioSource>();
        //设置不一开始就播放音效
        audioSource.playOnAwake = false;
    }
    void Start()
    {
        flag = false;
        killBugsNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 这里应该再加一个条件：目前拿着的物体是killBug杀虫剂 留在测试的时候加
        if (Input.GetKeyDown(KeyCode.Space) && killBugsNum != arrayLength)  //假设喷洒农药是按下空格键 如果按下了空格键并且虫子没有全部杀死
        {
            Debug.Log("按下了空格");
            Collider[] collider = Physics.OverlapBox(detectObject.transform.position, new Vector3(1, 1, 1)); // 创建碰撞进行范围检测
            Debug.Log("创建了碰撞体");
            for (int i = 0; i < collider.Length; i++)
            {
                //Debug.Log("正在检测"+i);
                //Debug.Log(collider[i].gameObject.name);
                if (collider[i].gameObject.name == "Cq_killBug") // 检测到的碰撞的物体是killBug杀虫剂的话
                {
                    Debug.Log("杀死一只虫子"+ Bugs[killBugsNum].name);
                    Debug.Log("播放音乐");
                    audioSource.Play();
                    Bugs[killBugsNum].GetComponent<Cq_FadeInOut>().FadeOut();
                    killBugsNum++;
                    
                }
            }
        }
        // 显现下一个panel
        if(killBugsNum == arrayLength && !flag)
        {
            canvas_appear.gameObject.SetActive(true);
            canvas_disappear.gameObject.SetActive(false);
            flag = true;
        }
    }
}
