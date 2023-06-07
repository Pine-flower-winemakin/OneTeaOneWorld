using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cq_KillBugs : MonoBehaviour
{
    public GameObject detectObject;
    public int arrayLength = 3;
    public GameObject[] Bugs;
    public int killBugsNum;
    public Canvas canvas_disappear;
    public Canvas canvas_appear;
    public AudioSource audioSource;  // ��Ч����
    private bool flag;
    public AudioClip audioClip;
    // Start is called before the first frame update

    private void Awake()
    {
        //���AudioSource���
        audioSource = gameObject.GetComponent<AudioSource>();
        //���ò�һ��ʼ�Ͳ�����Ч
        audioSource.playOnAwake = false;
    }
    void Start()
    {
        flag = false;
        killBugsNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // ����Ӧ���ټ�һ��������Ŀǰ���ŵ�������killBugɱ��� ���ڲ��Ե�ʱ���
        if (Input.GetKeyDown(KeyCode.Space) && killBugsNum != arrayLength)  //��������ũҩ�ǰ��¿ո�� ��������˿ո�����ҳ���û��ȫ��ɱ��
        {
            Debug.Log("�����˿ո�");
            Collider[] collider = Physics.OverlapBox(detectObject.transform.position, new Vector3(1, 1, 1)); // ������ײ���з�Χ���
            Debug.Log("��������ײ��");
            for (int i = 0; i < collider.Length; i++)
            {
                //Debug.Log("���ڼ��"+i);
                //Debug.Log(collider[i].gameObject.name);
                if (collider[i].gameObject.name == "Cq_killBug") // ��⵽����ײ��������killBugɱ����Ļ�
                {
                    Debug.Log("ɱ��һֻ����"+ Bugs[killBugsNum].name);
                    Debug.Log("��������");
                    audioSource.Play();
                    Bugs[killBugsNum].GetComponent<Cq_FadeInOut>().FadeOut();
                    killBugsNum++;
                    
                }
            }
        }
        // ������һ��panel
        if(killBugsNum == arrayLength && !flag)
        {
            canvas_appear.gameObject.SetActive(true);
            canvas_disappear.gameObject.SetActive(false);
            flag = true;
        }
    }
}
