using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chq_fireWoodTrigger : MonoBehaviour
{
    public GameObject fireWood_appear;
    public GameObject fireWood_disappear;
    public GameObject fireWood_disappear1;
    public GameObject fireWood_disappear2;

    public GameObject step2_appear;
    public GameObject fire_grab_appear;

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
        if(collider.tag == "chq_step1Dis")
        {
            //物体改变
            fireWood_appear.SetActive(true);
            fireWood_disappear.SetActive(false);
            fireWood_disappear1.SetActive(false);
            fireWood_disappear2.SetActive(false);

            //进入step2
            step2_appear.SetActive(true);
            fire_grab_appear.SetActive(true);
        }
    }
}
