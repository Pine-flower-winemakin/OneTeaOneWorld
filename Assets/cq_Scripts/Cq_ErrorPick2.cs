/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pvr_UnitySDKAPI;

public class Cq_ErrorPick2 : MonoBehaviour
{
    private XRGrabInteractable grab;
    // Start is called before the first frame update
    private void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        //Ϊactivated�¼���Ӽ�����������
        grab.activated.AddListener(GrabHandler);
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    private void GrabHandler(ActivateEventArgs a)
    {
        warning.GetComponent<Cq_Warning>().appear();
        print("����ɲ裺" + this.name);
    }
}

*/