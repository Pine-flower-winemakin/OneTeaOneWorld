using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chq_fireGrab : MonoBehaviour
{
    public GameObject fire;
    public GameObject selfDisp;
    public static int step = 0;

    public GameObject step1;
    public GameObject step2;
    public GameObject step3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider collider)
    {
        switch (step)
        {
            case 0:
                {
                    selfDisp.SetActive(false);
                    fire.SetActive(true);
                    step++;
                }
                break;
            case 1:
                {
                    selfDisp.SetActive(false);
                    fire.transform.localScale = new Vector3(0.7f,0.7f,0.7f);
                    step++;
                }
                break;
            case 2:
                {
                    selfDisp.SetActive(false);
                    fire.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    step1.SetActive(false);
                    step2.SetActive(false);
                    step3.SetActive(true);
                    chq_playChanzi.setFlagTrue();
                }
                break;
            default:
                break;
        }
        
    }
}
