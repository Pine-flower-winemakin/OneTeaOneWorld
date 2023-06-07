using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class slider : MonoBehaviour
{
    //public Slider mySlider;
    public Scrollbar myscrollbar;
    //public TextMeshProUGUI speedText;
    public Text speedText;
    public Transform indicatorTrans;
    public Transform processTrans;
    public ParticleSystem particleSystem;
    public GameObject lagan;

    GameObject parentObj;
    Button stopBtn;
    Button checkBtn;
    GameObject checkText;
    GameObject hb_circleProcessBar, hb_Scrollbar, tipText, endText;


    // public Text speedText;
    //���ͼ
    //private Image sliderImg;
    private Image scrollImg;

    bool toRight = true;
    bool isRun = true;
    bool isWrong = false;
    float timeCounter = 0;
    public double speed = 0.6;
    float taskNum = 5;//��������
    float curtaskNum = 0;//��ǰ����ɵ�������
    private TMP_Text indicator;
    //��ʱ��
    private float lastTime;
    private float curTime;
    private Transform laganPos;
    double maxZ = 0.07;
    double minZ = 0;
    bool isMoveLaganL = true;//������������
    private double curValue = 0;


    private double avgSpeed = 0;//ͳ���ܹ�ѡȡ�����ٶȾ�ֵ
    int chooseIdx = 0;//��ȡ��ѡ���ľ�����
    int starCnt = 0;//���Ǹ���������������
    bool lightRoast = false, mediumRoast = false, darkRoast = false;

    // Start is called before the first frame update
    void Start()
    {
        myscrollbar.value = 0;
        parentObj = GameObject.Find("hb_UI");
        stopBtn = parentObj.transform.Find("StopButton").GetComponent<Button>();
        checkText = parentObj.transform.Find("checkText").gameObject;
        checkBtn = parentObj.transform.Find("CheckButton").GetComponent<Button>();
        hb_circleProcessBar = parentObj.transform.Find("hb_circleProcessBar").gameObject;
        hb_Scrollbar = parentObj.transform.Find("hb_Scrollbar").gameObject;
        tipText = parentObj.transform.Find("tipText").gameObject;
        endText = parentObj.transform.Find("endText").gameObject;

        stopBtn.onClick.AddListener(OnStopButtonClick);
        //mySlider.value = 0;
        //sliderImg = mySlider.transform.Find("Fill Area/Fill").GetComponent<Image>();
        processTrans.GetComponent<Image>().fillAmount = 0;
        indicatorTrans.GetComponent<TMP_Text>().text = "0%";
        scrollImg = myscrollbar.transform.Find("Sliding Area/Handle").GetComponent<Image>();
        indicator = indicatorTrans.GetComponent<TMP_Text>();
        particleSystem = particleSystem.GetComponent<ParticleSystem>();
        laganPos = lagan.GetComponent<Transform>();
    }


    //�ƶ�����
    void MoveLaganPos(Transform laganPos, double speed)
    {
        if (isMoveLaganL)//��������z++
        {
            double moveL = laganPos.localPosition.z + speed * Time.deltaTime;
            if (moveL <= maxZ)
            {
                laganPos.localPosition = new Vector3(laganPos.localPosition.x, laganPos.localPosition.y, (float)(moveL));
            }
            else
            {
                isMoveLaganL = false;
            }
        }
        else
        {
            double moveR = laganPos.localPosition.z - speed * Time.deltaTime;
            if (moveR >= minZ)
            {
                laganPos.localPosition = new Vector3(laganPos.localPosition.x, laganPos.localPosition.y, (float)(moveR));
            }
            else
            {
                isMoveLaganL = true;
            }
        }
    }
    void getChooseIdx(int idx)
    {
        chooseIdx = idx;
    }


    private void OnStopButtonClick()
    {
        if (myscrollbar.value > 0.3f && myscrollbar.value <= 0.7f)
        {
            //isRun = false;
            curtaskNum += 1;
            print(curtaskNum);
            indicator.color = Color.white;
            indicatorTrans.GetComponent<TMP_Text>().text = (curtaskNum / taskNum * 100).ToString() + "%";
            processTrans.GetComponent<Image>().fillAmount = curtaskNum / taskNum;
            //���ƻ����С
            particleSystem.startSize = myscrollbar.value;
            particleSystem.startLifetime = (float)(0.3 * myscrollbar.value);
            //���������ƶ��ٶ�,z:0-0.5
            //MoveLaganPos(laganPos, myscrollbar.value * 0.1);
            curValue = myscrollbar.value;
            avgSpeed += myscrollbar.value;
        }
        else//����
        {
            indicator.color = Color.red;
            lastTime = Time.time;//��ʼ��ʱ
            isWrong = true;
            //���ƻ����С
            particleSystem.startSize = myscrollbar.value;
            particleSystem.startLifetime = (float)(0.3 * myscrollbar.value);
            //���������ƶ��ٶ�,z:0-0.5
            MoveLaganPos(laganPos, myscrollbar.value * 0.1);
            // System.Threading.Thread.Sleep(2000);//ֹͣ����
            // indicator.color = Color.white;
            curValue = myscrollbar.value;
        }
    }

    //����ѡ����Ϻ�ƽ���ٶȸ����÷֣�0.3-0.45��0.45-0.58��0.58-0.7
    void score(double avgSpeed)
    {
        if (avgSpeed >= 0.3 && avgSpeed <= 0.45)
        {
            lightRoast = true;
        }
        else if (avgSpeed > 0.45 && avgSpeed <= 0.58)
        {
            mediumRoast = true;
        }
        else if (avgSpeed > 0.58 && avgSpeed <= 0.7)
        {
            darkRoast = true;
        }

        if (chooseIdx == 1)
        {//̿�����
            if (darkRoast)
            {
                starCnt = 3;
            }
            else
            {
                starCnt = 2;
            }
        }
        else if (chooseIdx == 2)
        {//ľ�ġ����б�
            if (mediumRoast)
            {
                starCnt = 3;
            }
            else
            {
                starCnt = 2;
            }
        }
        else if (chooseIdx == 3)
        {
            //��̿����ǳ��
            if (lightRoast)
            {
                starCnt = 3;
            }
            else
            {
                starCnt = 2;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        //���������ƶ��ٶ�,z:0-0.5
        MoveLaganPos(laganPos, curValue * 0.2);
        //�ո������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (myscrollbar.value > 0.3f && myscrollbar.value <= 0.7f)
            {
                //isRun = false;
                curtaskNum += 1;
                print(curtaskNum);
                indicator.color = Color.white;
                indicatorTrans.GetComponent<TMP_Text>().text = (curtaskNum / taskNum * 100).ToString() + "%";
                processTrans.GetComponent<Image>().fillAmount = curtaskNum / taskNum;
                //���ƻ����С
                particleSystem.startSize = myscrollbar.value;
                particleSystem.startLifetime = (float)(0.3 * myscrollbar.value);
                //���������ƶ��ٶ�,z:0-0.5
                //MoveLaganPos(laganPos, myscrollbar.value * 0.1);
                curValue = myscrollbar.value;
                avgSpeed += myscrollbar.value;
            }
            else//����
            {
                indicator.color = Color.red;
                lastTime = Time.time;//��ʼ��ʱ
                isWrong = true;
                //���ƻ����С
                particleSystem.startSize = myscrollbar.value;
                particleSystem.startLifetime = (float)(0.3 * myscrollbar.value);
                //���������ƶ��ٶ�,z:0-0.5
                MoveLaganPos(laganPos, myscrollbar.value * 0.1);
                // System.Threading.Thread.Sleep(2000);//ֹͣ����
                // indicator.color = Color.white;
                curValue = myscrollbar.value;
            }
        }
        else
        {
            //���������ı�����ɫ
            if (myscrollbar.value > 0.7f)
            {
                //sliderImg.color = Color.red;
                scrollImg.color = Color.red;
                speedText.color = Color.red;
            }
            else if (myscrollbar.value > 0.3f)
            {
                //sliderImg.color = Color.green;
                speedText.color = Color.green;
                scrollImg.color = Color.green;
            }
            else
            {
                //sliderImg.color = Color.yellow;
                speedText.color = Color.yellow;
                scrollImg.color = Color.red;
            }
            if (curtaskNum >= taskNum)//����ȫ�����
            {
                //����ƽ���ٶ�
                avgSpeed /= (double)curtaskNum;
                score(avgSpeed);//��������м�����

                //��ʾ������������
                hb_circleProcessBar.SetActive(false);
                hb_Scrollbar.SetActive(false);
                speedText.gameObject.SetActive(false);
                //��ʾ��ʾ��Ϣ��ֹͣ��ť
                tipText.SetActive(false);
                stopBtn.gameObject.SetActive(false);

                //��ʾ�決���
                endText.SetActive(true);

                //��ƽ���ٶȵ�ֵ������һ������
                // GameObject.Find("hb_ChooseMaterials").GetComponent<selectMaterials>().SendMessage("score", avgSpeed);
            }
            else if (isWrong)//�������
            {
                curTime = Time.time;
                print(curTime - lastTime);
                if (curTime - lastTime >= 2f)//�������
                {
                    isWrong = false;
                    indicator.color = Color.white;
                }
            }
            else if (myscrollbar.value <= 1 && toRight && isRun)
            {
                myscrollbar.value += (float)(speed * Time.deltaTime);
                speedText.text = myscrollbar.value.ToString();
                //timeCounter += Time.deltaTime;
                if (myscrollbar.value >= 1)
                    toRight = false;
            }
            else if (myscrollbar.value >= 0 && !toRight && isRun)
            {
                myscrollbar.value -= (float)(speed * Time.deltaTime);
                speedText.text = myscrollbar.value.ToString();
                if (myscrollbar.value <= 0)
                    toRight = true;
            }
        }
    }
}
