using UnityEngine;
using UnityEngine.EventSystems;

public class Cq_Take : MonoBehaviour, IPointerClickHandler
{
    public bool isPickesUp = false;
    //利用鼠标click事件
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isPickesUp)
        {
            isPickesUp = true;
            // 因为拿起物体后物体会进行旋转 所以我们拿起物体后禁止旋转  //物体需要有刚体组件
            transform.GetComponent<Rigidbody>().freezeRotation = true;
        }
        else
        {
            isPickesUp = false;
            transform.GetComponent<Rigidbody>().freezeRotation = false;
        }
        print("点击了：：" + this.name);
    }

    private void Update()
    {
        if (isPickesUp)
        {
            //首先获取到当前物体的屏幕坐标
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            float fixedX = 100f; // 假设物体侧面的X轴位置为100
            //Vector3 m_MousePos = new Vector3(fixedX, Input.mousePosition.y, pos.z);
            //让鼠标的屏幕坐标的Z轴等于当前物体的屏幕坐标的Z轴，也就是相隔的距离
            Vector3 m_MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pos.z);
            //将正确的鼠标屏幕坐标换成世界坐标交给物体
            transform.position = Camera.main.ScreenToWorldPoint(m_MousePos);
            //计算物体应该旋转的角度，使其侧面始终朝向摄像机。
            Vector3 direction = Camera.main.transform.position - transform.position;
            direction.x -= 90;
            Quaternion rotation = Quaternion.LookRotation(-direction, new Vector3(0, 1, 0));
            transform.rotation = rotation;

        }
    }
}
