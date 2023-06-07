using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cq_Warning : MonoBehaviour
{
    public float fadeSpeed = 1.5f;          // 淡入淡出速度
    public float delayTime = 3.0f;          // 淡出延迟时间
    private Renderer rend;                  // 物体的渲染器组件

    void Start()
    {
        rend = GetComponent<Renderer>();
        Color color = rend.material.color;
        color.a = 0f;                       // 初始设为透明
        rend.material.color = color;
    }

    public void appear()
    {
        // 启动一个协程
        StartCoroutine(FadeInAndOut());
    }

    public IEnumerator FadeInAndOut()
    {
        Debug.Log("开始协程");
        // 淡入
        while (rend.material.color.a < 1f)
        {
            Debug.Log("开始淡入");
            Color color = rend.material.color;
            color.a += Time.deltaTime * fadeSpeed;
            rend.material.color = color;
            yield return null;
        }

        // 延迟
        yield return new WaitForSeconds(delayTime);

        // 淡出
        while (rend.material.color.a > 0f)
        {
            Debug.Log("开始淡出");
            Color color = rend.material.color;
            color.a -= Time.deltaTime * fadeSpeed;
            rend.material.color = color;
            yield return null;
        }
    }
}