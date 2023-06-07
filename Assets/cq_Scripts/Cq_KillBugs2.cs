using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Cq_KillBugs2 : MonoBehaviour
{
    public GameObject detectObject;
    public int arrayLength = 3;
    public GameObject[] Bugs;
    public int killBugsNum;
    public Canvas canvas_disappear;
    public Canvas canvas_appear;
    public AudioSource audioSource;  // ��Ч����
                                     //*************�������**************************
    InputDevice leftHandController;
    InputDevice rightHandController;
    InputDevice headController;
    bool triggerValue;
    public AudioClip audioClip;
    //�ṩ״̬�ֵ������¼����feature��״̬
    Dictionary<string, bool> stateDic;
    // Start is called before the first frame update

    private void Init()
    {
        // ��ȡ��Ӧ��InputDevice����
        if (!leftHandController.isValid)
        {
            leftHandController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        }
        if (!rightHandController.isValid)
        {
            rightHandController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        }
        if (!headController.isValid)
        {
            headController = InputDevices.GetDeviceAtXRNode(XRNode.Head);
        }

        stateDic = new Dictionary<string, bool>();

    }

    private void Awake()
    {
        //���AudioSource���
        audioSource = gameObject.GetComponent<AudioSource>();
        //���ò�һ��ʼ�Ͳ�����Ч
        audioSource.playOnAwake = false;
    }
    void Start()
    {
        Init();
        killBugsNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // ����Ӧ���ټ�һ��������Ŀǰ���ŵ�������killBugɱ��� ���ڲ��Ե�ʱ��� ���ְ���trigger��
        if (leftHandController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            //Debug.Log("�����˿ո�");
            Collider[] collider = Physics.OverlapBox(detectObject.transform.position, new Vector3(1, 1, 1)); // ������ײ���з�Χ���
            Debug.Log("��������ײ��");
            for (int i = 0; i < collider.Length; i++)
            {
                //Debug.Log("���ڼ��"+i);
                //Debug.Log(collider[i].gameObject.name);
                if (collider[i].gameObject.name == "Cq_killBug") // ��⵽����ײ��������killBugɱ����Ļ�
                {
                    Debug.Log("ɱ��һֻ����" + Bugs[killBugsNum].name);
                    Debug.Log("��������");
                    audioSource.Play();
                    Bugs[killBugsNum].SetActive(false);
                    // Bugs[killBugsNum].GetComponent<Cq_FadeInOut>().FadeOut();
                    killBugsNum++;
                    break;
                }
            }

        }

        // ������һ��panel
        if (killBugsNum == arrayLength)
        {
            audioSource.clip = audioClip;
            canvas_appear.gameObject.SetActive(true);
            canvas_disappear.gameObject.SetActive(false);
            audioSource.Play();
        }
    }
}