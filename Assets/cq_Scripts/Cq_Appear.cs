using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cq_Appear : MonoBehaviour
{
    // 这里是将要显示的三个茶叶的集合
    public GameObject teaSet1;
    public GameObject teaSet2;
    public GameObject teaSet3;
    public Canvas canvas_disappear;
    public Canvas canvas_appear;
    private string Message;
    private bool[] flags = new bool[3] { false,false,false };
    public AudioSource audioSource; // 音频源

    //利用碰撞来实现茶叶的消失与出现
    //碰撞开始

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision)
    {

        // 有些情况下，子物体的碰撞器/触发器会触发父物体的“OnCollisionEnter”、“OnTriggerEnter”函数
        //1.比如，父物体添加Rigidbody刚体，没有碰撞器，子物体没有Rigidbody，有碰撞器，父物体会触发“OnCollisionEnter”，子物体不会。
        //2.如果，父物体添加Rigidbody刚体，有碰撞器，子物体没有Rigidbody，有碰撞器，父物体会触发“OnCollisionEnter”（碰撞到父物体碰撞器或子物体碰撞器，都会触发父物体回调），子物体仍然不会。

        if (collision.gameObject.name == "Cq_Tea")
        {
            Message = "进入碰撞,碰撞名称：" + collision.gameObject.name;
            print(Message);

            // 产生碰撞的茶叶逐渐消失
            collision.gameObject.GetComponent<Cq_FadeInOut>().FadeOut();
            collision.gameObject.SetActive(false);

            //三堆茶叶分批次出现
            if (!flags[0])
            {
                teaSet1.SetActive(true);
                //teaSet1.GetComponent<Cq_FadeInOut>().FadeIn();
                flags[0] = true;
            }
            else if(!flags[1])
            {
                teaSet2.SetActive(true);
                //teaSet2.GetComponent<Cq_FadeInOut>().FadeIn();
                flags[1] = true;
            }
            else
            {
                //teaSet3.GetComponent<Cq_FadeInOut>().FadeIn();
                teaSet3.SetActive(true);
                flags[2] = true;
                canvas_appear.gameObject.SetActive(true);
                canvas_disappear.gameObject.SetActive(false);
                StartCoroutine(PlayMusicAfterDelay(3f));
                //由于FadeInOut脚本已经遍历了子物体 那么这里就不需要遍历子物体了
                //Transform[] myTransforms = GetComponentsInChildren<Transform>();
                //foreach (var child in myTransforms)
                //{
                //    if(child.GetComponent<FadeInOut>())
                //        child.GetComponent<FadeInOut>().FadeIn();
                //}
            }
        }
    }
    private IEnumerator PlayMusicAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Play();
    }
}
