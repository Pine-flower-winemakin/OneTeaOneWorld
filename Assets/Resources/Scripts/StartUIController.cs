using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUIController : MonoBehaviour
{
    // Start is called before the first frame update
    public  Transform XROrigin;
    public Transform ChaoQinTransform;
    public Transform ShaiQinTransform;
   // public Transform HongBeiTransform;
    // public Transform CaiQinTransform;


    public void OnChaoQinButtonClick()
    {
        XROrigin.position = ChaoQinTransform.position;
    }

    public void OnShaiQinButtonClick()
    {
        XROrigin.position = ShaiQinTransform.position;
        Teleport(XROrigin, ShaiQinTransform.position);

    }

    private void Teleport(Transform target, Vector3 destination)
    {
        target.position = destination;

        // 递归处理子物体
        for (int i = 0; i < target.childCount; i++)
        {
            Transform child = target.GetChild(i);
            Teleport(child, child.position - target.position + destination);
        }
    }

}
