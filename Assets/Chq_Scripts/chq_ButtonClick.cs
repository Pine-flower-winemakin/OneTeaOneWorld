using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chq_ButtonClick : MonoBehaviour
{
    public GameObject start;
    public GameObject step1;
    public GameObject step2;
    public GameObject next;
    public GameObject step3;
    public GameObject finish;

    public chq_ButtonClick()
    {

    }

    public chq_ButtonClick(GameObject s1, GameObject s2, GameObject s3)
    {
        step1 = s1;
        step2 = s2;
        step3 = s3;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startButtonOn()
    {
        start.SetActive(false);
        step1.SetActive(true);
    }

    public void nextButtonOn()
    {
        step1.SetActive(false);
        step2.SetActive(false);
        next.SetActive(false);
        step3.SetActive(true);
    }



        
}
