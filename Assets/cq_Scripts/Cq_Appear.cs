using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cq_Appear : MonoBehaviour
{
    // �����ǽ�Ҫ��ʾ��������Ҷ�ļ���
    public GameObject teaSet1;
    public GameObject teaSet2;
    public GameObject teaSet3;
    public Canvas canvas_disappear;
    public Canvas canvas_appear;
    private string Message;
    private bool[] flags = new bool[3] { false,false,false };
    public AudioSource audioSource; // ��ƵԴ

    //������ײ��ʵ�ֲ�Ҷ����ʧ�����
    //��ײ��ʼ

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision)
    {

        // ��Щ����£����������ײ��/�������ᴥ��������ġ�OnCollisionEnter������OnTriggerEnter������
        //1.���磬���������Rigidbody���壬û����ײ����������û��Rigidbody������ײ����������ᴥ����OnCollisionEnter���������岻�ᡣ
        //2.��������������Rigidbody���壬����ײ����������û��Rigidbody������ײ����������ᴥ����OnCollisionEnter������ײ����������ײ������������ײ�������ᴥ��������ص�������������Ȼ���ᡣ

        if (collision.gameObject.name == "Cq_Tea")
        {
            Message = "������ײ,��ײ���ƣ�" + collision.gameObject.name;
            print(Message);

            // ������ײ�Ĳ�Ҷ����ʧ
            collision.gameObject.GetComponent<Cq_FadeInOut>().FadeOut();
            collision.gameObject.SetActive(false);

            //���Ѳ�Ҷ�����γ���
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
                //����FadeInOut�ű��Ѿ������������� ��ô����Ͳ���Ҫ������������
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
