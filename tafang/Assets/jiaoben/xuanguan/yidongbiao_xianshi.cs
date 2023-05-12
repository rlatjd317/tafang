using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yidongbiao_xianshi : MonoBehaviour
{
    Camera cam;

    float zuojixian;
    float xiajixian;

    GameObject zuo;
    GameObject xia;
    private void Start()
    {
        cam = Camera.main;
        zuo = GameObject.Find("yidongbiao/zuo");
        xia = GameObject.Find("yidongbiao/xia");
        zuojixian = 0;
        xiajixian = 0;
    }

    private void Update()
    {
        if (cam.transform.position.x <= zuojixian)
        {
            zuo.transform.localScale = Vector3.zero;
            cam.transform.position = new Vector3(zuojixian, cam.transform.position.y, cam.transform.position.z);
        }
        else
        {
            zuo.transform.localScale = Vector3.one;
        }

        if (cam.transform.position.y <= xiajixian)
        {
            xia.transform.localScale = Vector3.zero;
            cam.transform.position = new Vector3(cam.transform.position.x, xiajixian, cam.transform.position.z);
        }
        else
        {
            xia.transform.localScale = Vector3.one;
        }
    }

    public void yuandian()
    {
        cam.transform.position = Vector3.zero;
    }
}
