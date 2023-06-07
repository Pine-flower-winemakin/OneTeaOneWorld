using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class my_test : MonoBehaviour
{
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(onclick);
    }

    void onclick()
    {
        print("clicked");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
