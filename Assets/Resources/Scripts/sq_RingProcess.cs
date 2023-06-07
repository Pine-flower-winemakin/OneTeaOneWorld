using UnityEngine;
using UnityEngine.UI;

public class sq_RingProcess : MonoBehaviour
{
    //进度条速度
    public float speed;
    //一个图片一个文字
    public Transform m_Image;
    public Transform m_Text;
    //进度控制
    public int targetProcess = 100;
    private float currentAmout = 0;

    void Update()
    {
        if (currentAmout < targetProcess)
        {
            currentAmout += speed;
            if (currentAmout > targetProcess)
                currentAmout = targetProcess;
            m_Text.GetComponent<Text>().text = ((int)currentAmout).ToString() + "%";
            m_Image.GetComponent<Image>().fillAmount = currentAmout / 100.0f;
        }
    }
}

