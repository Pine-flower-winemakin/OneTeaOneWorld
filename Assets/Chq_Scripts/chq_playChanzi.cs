using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chq_playChanzi : MonoBehaviour
{
    public GameObject scollBar;
    public static int count = 0;
    public int basevalue = 10;
    public static bool flag = false;
    public static float rate;
    public GameObject[] gameObjects;
    public Vector3 old;
    public static Material m1, m2;
    public GameObject step3;
    public GameObject finish;

    // Start is called before the first frame update
    void Start()
    {
        //scollBar = GameObject.Find("processBar");
        gameObjects = GameObject.FindGameObjectsWithTag("chq_tea");
        old = transform.localScale;
        m1 = GameObject.Find("mat1").GetComponent<Renderer>().material;
        m2 = GameObject.Find("mat2").GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public static void setFlagTrue()
    {
        flag = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (flag)
        {
            print(count.ToString());
            if (collider.tag == "chq_trace")
            {
                count++;
                rate =(float) count / basevalue;
                scollBar.GetComponent<Scrollbar>().size = rate;
                if ( rate >= 1.0f)  //½áÊøÌõ¼þ
                {
                    flag = false;
                    for (int i = 0; i < gameObjects.Length; i++)
                    {
                        float fact = 0.75f;
                        gameObjects[i].transform.localScale = new Vector3(old.x * fact, old.y * fact, old.z * fact);
                        foreach (Transform t in gameObjects[i].GetComponentsInChildren<Transform>())
                        {
                            if (t.name == "uploads_files_748162_OBJ6:Cylinder001" ||
                                t.name == "uploads_files_748162_OBJ6:Plane001" ||
                                t.name == "pasted__Cylinder001" ||
                                t.name == "pasted__Plane001")
                            {
                                t.GetComponent<Renderer>().material = m2;
                            }
                        }
                        step3.SetActive(false);
                        finish.SetActive(true);
                    } 
                }
                //else if(rate >= 0.2f)
                //{
                //    for(int i = 0; i < gameObjects.Length; i++)
                //    {
                //        float fact = 0.95f;
                //        gameObjects[i].transform.localScale = new Vector3(old.x * fact, old.y * fact, old.z * fact);
                //    }
                //    //Vector3 old = transform.localScale;
                //    //float fact = 0.7f;
                //    //transform.localScale = new Vector3(old.x*fact, old.y*fact, old.z*fact);
                //}
                else if(rate >= 0.5f)
                {
                    for (int i = 0; i < gameObjects.Length; i++)
                    {
                        float fact = 0.90f;
                        gameObjects[i].transform.localScale = new Vector3(old.x * fact, old.y * fact, old.z * fact);
                        //foreach (Transform t in gameObjects[i].GetComponentsInChildren<Transform>())
                        //{
                        //    if (t.name == "uploads_files_748162_OBJ6:Cylinder001" ||
                        //        t.name == "uploads_files_748162_OBJ6:Plane001" ||
                        //        t.name == "pasted__Cylinder001" ||
                        //        t.name == "pasted__Plane001")
                        //    {
                        //        t.GetComponent<Renderer>().material = m1;
                        //    }
                        //}
                    }
                    //Vector3 old = transform.localScale;
                    //float fact = 0.5f;
                    //transform.localScale = new Vector3(old.x * fact, old.y * fact, old.z * fact);
                }
                else if(rate>= 0.8f)
                {
                    for (int i = 0; i < gameObjects.Length; i++)
                    {
                        float fact = 0.80f;
                        gameObjects[i].transform.localScale = new Vector3(old.x * fact, old.y * fact, old.z * fact);
                    }
                }
            }
        }
        
    }
}
