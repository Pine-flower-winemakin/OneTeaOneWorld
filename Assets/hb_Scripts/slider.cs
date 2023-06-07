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
    //填充图
    //private Image sliderImg;
    private Image scrollImg;

    bool toRight = true;
    bool isRun = true;
    bool isWrong = false;
    float timeCounter = 0;
    public double speed = 0.6;
    float taskNum = 5;//总任务数
    float curtaskNum = 0;//当前已完成的任务数
    private TMP_Text indicator;
    //计时器
    private float lastTime;
    private float curTime;
    private Transform laganPos;
    double maxZ = 0.07;
    double minZ = 0;
    bool isMoveLaganL = true;//将拉杆向外拉
    private double curValue = 0;


    private double avgSpeed = 0;//统计总共选取的总速度均值
    int chooseIdx = 0;//获取的选择的木材序号
    int starCnt = 0;//星星个数，满分三颗星
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


    //移动拉杆
    void MoveLaganPos(Transform laganPos, double speed)
    {
        if (isMoveLaganL)//向外拉，z++
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
            //控制火焰大小
            particleSystem.startSize = myscrollbar.value;
            particleSystem.startLifetime = (float)(0.3 * myscrollbar.value);
            //控制拉杆移动速度,z:0-0.5
            //MoveLaganPos(laganPos, myscrollbar.value * 0.1);
            curValue = myscrollbar.value;
            avgSpeed += myscrollbar.value;
        }
        else//按错
        {
            indicator.color = Color.red;
            lastTime = Time.time;//开始计时
            isWrong = true;
            //控制火焰大小
            particleSystem.startSize = myscrollbar.value;
            particleSystem.startLifetime = (float)(0.3 * myscrollbar.value);
            //控制拉杆移动速度,z:0-0.5
            MoveLaganPos(laganPos, myscrollbar.value * 0.1);
            // System.Threading.Thread.Sleep(2000);//停止两秒
            // indicator.color = Color.white;
            curValue = myscrollbar.value;
        }
    }

    //根据选择材料和平均速度给出得分，0.3-0.45，0.45-0.58，0.58-0.7
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
        {//炭——深焙
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
        {//木材——中焙
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
            //竹炭——浅焙
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
        //控制拉杆移动速度,z:0-0.5
        MoveLaganPos(laganPos, curValue * 0.2);
        //空格键按下
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
                //控制火焰大小
                particleSystem.startSize = myscrollbar.value;
                particleSystem.startLifetime = (float)(0.3 * myscrollbar.value);
                //控制拉杆移动速度,z:0-0.5
                //MoveLaganPos(laganPos, myscrollbar.value * 0.1);
                curValue = myscrollbar.value;
                avgSpeed += myscrollbar.value;
            }
            else//按错
            {
                indicator.color = Color.red;
                lastTime = Time.time;//开始计时
                isWrong = true;
                //控制火焰大小
                particleSystem.startSize = myscrollbar.value;
                particleSystem.startLifetime = (float)(0.3 * myscrollbar.value);
                //控制拉杆移动速度,z:0-0.5
                MoveLaganPos(laganPos, myscrollbar.value * 0.1);
                // System.Threading.Thread.Sleep(2000);//停止两秒
                // indicator.color = Color.white;
                curValue = myscrollbar.value;
            }
        }
        else
        {
            //进度条和文本的颜色
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
            if (curtaskNum >= taskNum)//任务全部完成
            {
                //计算平均速度
                avgSpeed /= (double)curtaskNum;
                score(avgSpeed);//计算最后有几颗星

                //显示进度条和文字
                hb_circleProcessBar.SetActive(false);
                hb_Scrollbar.SetActive(false);
                speedText.gameObject.SetActive(false);
                //显示提示信息和停止按钮
                tipText.SetActive(false);
                stopBtn.gameObject.SetActive(false);

                //显示烘焙完成
                endText.SetActive(true);

                //将平均速度的值传给另一个函数
                // GameObject.Find("hb_ChooseMaterials").GetComponent<selectMaterials>().SendMessage("score", avgSpeed);
            }
            else if (isWrong)//点击错误
            {
                curTime = Time.time;
                print(curTime - lastTime);
                if (curTime - lastTime >= 2f)//过两秒后
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
