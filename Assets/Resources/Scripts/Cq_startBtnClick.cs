using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cq_startBtnClick : MonoBehaviour
{
    public Button btn;
    public Canvas canvas_disappear;
    public Canvas canvas_appear;
    public AudioSource audioSource;

    void Start()
    {
        // 增加监听事件
        btn.onClick.AddListener(OnClick);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnClick()
    {
        Debug.Log("Button Clicked. ClickHandler.");
        canvas_appear.gameObject.SetActive(true);
        canvas_disappear.enabled = false;
        audioSource.Play();
    }
}
