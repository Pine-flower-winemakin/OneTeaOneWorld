using UnityEngine;
using UnityEngine.EventSystems;

public class Cq_FalseEventClick : MonoBehaviour, IPointerClickHandler
{
    // public bool isPickesUp = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        //if (!isPickesUp)
        //    isPickesUp = true;
        //else
        //    isPickesUp = false;
        print("�����~~~~~��Ҷ�Ӳ��ܲ�ժ" + this.name);
        // ����UI
        ShowUI();

    }
    private void ShowUI()
    {
        // ʵ��
        print("�������ܲ�ժ��UI");
    }
    private void Update()
    {

    }
}

