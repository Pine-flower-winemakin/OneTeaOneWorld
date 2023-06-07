using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class selectMaterials : MonoBehaviour
{
    GameObject parentObj;
    GameObject tObj, mcObj, ztObj, zmObj;
    GameObject tText, mcText, ztText, zmText, startText, checkText;
    GameObject startTitle, selectTitle;
    Button startBtn, mucaiBtn, mutanBtn, zhutanBtn, selectBtn, checkBtn;
    GameObject hb_circleProcessBar, hb_Scrollbar, speedText, tipText;
    Button stopBtn;

    int curIdx = 0, chooseIdx = 0;

    // Start is called before the first frame update
    void Start()
    {
        parentObj = GameObject.Find("hb_UI");
        //parentObj = parentObj.transform.Find("hb_director_1").gameObject;

        mcObj = parentObj.transform.Find("MucaiImg").gameObject;
        tObj = parentObj.transform.Find("MutanImg").gameObject;
        /* zmObj = parentObj.transform.Find("hb_moniZhiMa").gameObject;*/
        ztObj = parentObj.transform.Find("ZhutanImg").gameObject;

        tText = parentObj.transform.Find("mtText").gameObject;
        mcText = parentObj.transform.Find("mcText").gameObject;
        ztText = parentObj.transform.Find("ztText").gameObject;
        startText = parentObj.transform.Find("startText").gameObject;
        checkText = parentObj.transform.Find("checkText").gameObject;

        startTitle = parentObj.transform.Find("start_title").gameObject;
        selectTitle = parentObj.transform.Find("select_title").gameObject;

        startBtn = parentObj.transform.Find("StartButton").GetComponent<Button>();
        mucaiBtn = parentObj.transform.Find("MuCaiButton").GetComponent<Button>();
        mutanBtn = parentObj.transform.Find("MuTanButton").GetComponent<Button>();
        zhutanBtn = parentObj.transform.Find("ZhuTanButton").GetComponent<Button>();
        selectBtn = parentObj.transform.Find("SelectButton").GetComponent<Button>();
        checkBtn = parentObj.transform.Find("CheckButton").GetComponent<Button>();
        stopBtn = parentObj.transform.Find("StopButton").GetComponent<Button>();

        hb_circleProcessBar = parentObj.transform.Find("hb_circleProcessBar").gameObject;
        hb_Scrollbar = parentObj.transform.Find("hb_Scrollbar").gameObject;
        speedText = parentObj.transform.Find("speedText").gameObject;
        tipText = parentObj.transform.Find("tipText").gameObject;

        zhutanBtn.GetComponent<Image>().color = Color.blue;
        mucaiBtn.GetComponent<Image>().color = Color.blue;
        mutanBtn.GetComponent<Image>().color = Color.blue;

        startBtn.onClick.AddListener(OnStartButtonClick);//��Ӽ����¼�
        mucaiBtn.onClick.AddListener(OnMucaiButtonClick);
        mutanBtn.onClick.AddListener(OnMutanButtonClick);
        zhutanBtn.onClick.AddListener(OnZhutanButtonClick);

        selectBtn.onClick.AddListener(OnSelcetButtonClick);
        checkBtn.onClick.AddListener(OnCheckButtonClick);
        //������ʾ ���� GameObject.SetActive(false);
    }

    private void OnStartButtonClick()
    {
        startText.SetActive(false);
        startBtn.gameObject.SetActive(false);
        startTitle.SetActive(false);

        selectTitle.SetActive(true);
        mucaiBtn.gameObject.SetActive(true);
        mutanBtn.gameObject.SetActive(true);
        zhutanBtn.gameObject.SetActive(true);
        selectBtn.gameObject.SetActive(true);

        ztText.SetActive(true);
        ztObj.SetActive(true);
        zhutanBtn.gameObject.SetActive(true);
        zhutanBtn.GetComponent<Image>().color = Color.green;
    }

    private void OnMucaiButtonClick()
    {
        if (ztText.activeInHierarchy)//ԭ������̿
        {
            ztText.SetActive(false);
            ztObj.SetActive(false);
            zhutanBtn.GetComponent<Image>().color = Color.blue;
        }
        else if (tText.activeInHierarchy)//ԭ����ľ̿
        {
            tText.SetActive(false);
            tObj.SetActive(false);
            mutanBtn.GetComponent<Image>().color = Color.blue;
        }
        mcText.SetActive(true);
        mcObj.SetActive(true);
        mucaiBtn.GetComponent<Image>().color = Color.green;
    }

    private void OnMutanButtonClick()
    {
        if (ztText.activeInHierarchy)//ԭ������̿
        {
            ztText.SetActive(false);
            ztObj.SetActive(false);
            zhutanBtn.GetComponent<Image>().color = Color.blue;
        }
        else if (mcText.activeInHierarchy)//ԭ����ľ��
        {
            mcText.SetActive(false);
            mcObj.SetActive(false);
            mucaiBtn.GetComponent<Image>().color = Color.blue;
        }
        tText.SetActive(true);
        tObj.SetActive(true);
        mutanBtn.GetComponent<Image>().color = Color.green;
    }

    private void OnZhutanButtonClick()
    {
        if (tText.activeInHierarchy)//ԭ����ľ̿
        {
            tText.SetActive(false);
            tObj.SetActive(false);
            mutanBtn.GetComponent<Image>().color = Color.blue;
        }
        else if (mcText.activeInHierarchy)//ԭ����ľ��
        {
            mcText.SetActive(false);
            mcObj.SetActive(false);
            mucaiBtn.GetComponent<Image>().color = Color.blue;
        }
        ztText.SetActive(true);
        ztObj.SetActive(true);
        zhutanBtn.GetComponent<Image>().color = Color.green;
    }

    private void OnSelcetButtonClick()
    {
        //���ı���ͼƬ�Ͱ�ť����ʧ��������ʾ��Ϣ�����ȷ�Ͻ�����һ�׶Ρ���ֹͣ��ť�ͽ��ȿ�
        if (tText.activeInHierarchy)//ԭ����ľ̿
        {
            tText.SetActive(false);
            tObj.SetActive(false);
        }
        else if (mcText.activeInHierarchy)//ԭ����ľ��
        {
            mcText.SetActive(false);
            mcObj.SetActive(false);
        }
        else if (ztText.activeInHierarchy)//ԭ������̿
        {
            ztText.SetActive(false);
            ztObj.SetActive(false);
        }
        zhutanBtn.gameObject.SetActive(false);
        mucaiBtn.gameObject.SetActive(false);
        mutanBtn.gameObject.SetActive(false);
        selectBtn.gameObject.SetActive(false);
        selectTitle.SetActive(false);

        //������ʾ��Ϣ
        checkBtn.gameObject.SetActive(true);
        checkText.SetActive(true);
    }

    private void OnCheckButtonClick()
    {
        checkBtn.gameObject.SetActive(false);
        checkText.SetActive(false);
        //��ʾ������������
        hb_circleProcessBar.SetActive(true);
        hb_Scrollbar.SetActive(true);
        speedText.SetActive(true);
        //��ʾ��ʾ��Ϣ��ֹͣ��ť
        tipText.SetActive(true);
        stopBtn.gameObject.SetActive(true);
    }

    /*  void showCurrent(int i)//����Ҫ��ʾ�鿴�����ĸ�
      {
          if (i == 1)
          {
              tObj.SetActive(true);
              tText.SetActive(true);
              mcObj.SetActive(false);
              mcText.SetActive(false);
              ztObj.SetActive(false);
              ztText.SetActive(false);
          }
          else if (i == 2)
          {
              tObj.SetActive(false);
              tText.SetActive(false);
              mcObj.SetActive(true);
              mcText.SetActive(true);
              ztObj.SetActive(false);
              ztText.SetActive(false);

          }
          else if (i == 3)
          {
              tObj.SetActive(false);
              tText.SetActive(false);
              mcObj.SetActive(false);
              mcText.SetActive(false);
              ztObj.SetActive(true);
              ztText.SetActive(true);
          }

      }
  */
    // Update is called once per frame
    void Update()
    {
        /*  if (Input.GetKeyDown(KeyCode.Alpha1))//̿
          {
              showCurrent(1);
              curIdx = 1;
          }
          if (Input.GetKeyDown(KeyCode.Alpha2))//ľ��
          {
              showCurrent(2);
              curIdx = 2;
          }
          if (Input.GetKeyDown(KeyCode.Alpha3))//��̿
          {
              showCurrent(3);
              curIdx = 3;
          }
          *//* if (Input.GetKeyDown(KeyCode.Alpha4))//֥��̿
           {
               showCurrent(4);
               curIdx = 4;
           }*//*
          if (Input.GetKeyDown(KeyCode.Space))
          {
              //�ո��ȷ��ѡ��
              chooseIdx = curIdx;
              GameObject.Find("hb_Canvas").GetComponent<slider>().SendMessage("getChooseIdx", chooseIdx);
          }*/
    }
}
