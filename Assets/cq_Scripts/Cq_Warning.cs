using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cq_Warning : MonoBehaviour
{
    public float fadeSpeed = 1.5f;          // ���뵭���ٶ�
    public float delayTime = 3.0f;          // �����ӳ�ʱ��
    private Renderer rend;                  // �������Ⱦ�����

    void Start()
    {
        rend = GetComponent<Renderer>();
        Color color = rend.material.color;
        color.a = 0f;                       // ��ʼ��Ϊ͸��
        rend.material.color = color;
    }

    public void appear()
    {
        // ����һ��Э��
        StartCoroutine(FadeInAndOut());
    }

    public IEnumerator FadeInAndOut()
    {
        Debug.Log("��ʼЭ��");
        // ����
        while (rend.material.color.a < 1f)
        {
            Debug.Log("��ʼ����");
            Color color = rend.material.color;
            color.a += Time.deltaTime * fadeSpeed;
            rend.material.color = color;
            yield return null;
        }

        // �ӳ�
        yield return new WaitForSeconds(delayTime);

        // ����
        while (rend.material.color.a > 0f)
        {
            Debug.Log("��ʼ����");
            Color color = rend.material.color;
            color.a -= Time.deltaTime * fadeSpeed;
            rend.material.color = color;
            yield return null;
        }
    }
}