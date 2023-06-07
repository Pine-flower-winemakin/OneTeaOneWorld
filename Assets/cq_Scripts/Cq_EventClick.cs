using UnityEngine;
using UnityEngine.EventSystems;

public class Cq_EventClick : MonoBehaviour, IPointerClickHandler
{
    public bool isPickesUp = false;
    //�������click�¼�
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isPickesUp)
        {
            isPickesUp = true;
            // ��Ϊ�������������������ת ������������������ֹ��ת  //������Ҫ�и������
            transform.GetComponent<Rigidbody>().freezeRotation = true;
        }
        else
        {
            isPickesUp = false;
            transform.GetComponent<Rigidbody>().freezeRotation = false;
        }
        print("����ˣ���" + this.name);
    }

    private void Update()
    {
        if (isPickesUp)
        {
            //���Ȼ�ȡ����ǰ�������Ļ����
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            //��������Ļ�����Z����ڵ�ǰ�������Ļ�����Z�ᣬҲ��������ľ���
            Vector3 m_MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pos.z);
            //����ȷ�������Ļ���껻���������꽻������
            transform.position = Camera.main.ScreenToWorldPoint(m_MousePos);
        }
    }
}