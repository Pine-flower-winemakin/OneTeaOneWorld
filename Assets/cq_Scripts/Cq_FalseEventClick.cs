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
        print("点错啦~~~~~该叶子不能采摘" + this.name);
        // 调出UI
        ShowUI();

    }
    private void ShowUI()
    {
        // 实现
        print("调出不能采摘的UI");
    }
    private void Update()
    {

    }
}

