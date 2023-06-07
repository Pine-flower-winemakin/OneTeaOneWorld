/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cq_RayCtrl : MonoBehaviour
{

    private LineRenderer line;
    public GameObject NowGameObject;

    private GameObject StartPos;
    public static Vector3 hitPos;
    public Transform dot;

    private RaycastHit hit;

    public static string name;

    // Use this for initialization
    void Start()
    {
        line = transform.Find("ray_LengthAdaptive").GetComponent<LineRenderer>();
        line.gameObject.SetActive(true);
        dot = transform.Find("dot");
        dot.gameObject.SetActive(true);
        StartPos = GameObject.Find("StartPos");
        hitPos = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray { origin = StartPos.transform.position, direction = StartPos.transform.forward };
        line.SetPosition(0, ray.origin);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            line.SetPosition(1, hit.point);
            line.startColor = Color.green;
            dot.position = hit.point;
            hitPos = hit.point;
            NowGameObject = hit.transform.gameObject;
            name = NowGameObject.name;
        }
        else
        {
            line.SetPosition(1, ray.origin + ray.direction * 2);
            line.startColor = Color.red;
            dot.position = ray.origin + ray.direction * 2;
            hitPos = ray.origin + ray.direction * 2;
            name = null;
        }
    }
}*/