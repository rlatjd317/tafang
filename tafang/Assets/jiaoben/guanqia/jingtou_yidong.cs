using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jingtou_yidong : MonoBehaviour
{
    GameObject shang;
    GameObject xia;
    GameObject zuo;
    GameObject you;
    public float shangjixian;
    public float xiajixian;
    public float zuojixian;
    public float youjixian;
    public bool kesuofang;
    public float suoxiaojixian;
    public float fangdajixian;
    Camera cam;
    private void Start()
    {
        shang = GameObject.Find("yidongbiao/shang");
        xia = GameObject.Find("yidongbiao/xia");
        zuo = GameObject.Find("yidongbiao/zuo");
        you = GameObject.Find("yidongbiao/you");
        cam = Camera.main;
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

        if (cam.transform.position.x >= youjixian)
        {
            you.transform.localScale = Vector3.zero;
            cam.transform.position = new Vector3(youjixian, cam.transform.position.y, cam.transform.position.z);
        }
        else
        {
            you.transform.localScale = Vector3.one;
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

        if (cam.transform.position.y >= shangjixian)
        {
            shang.transform.localScale = Vector3.zero;
            cam.transform.position = new Vector3(cam.transform.position.x, shangjixian, cam.transform.position.z);
        }
        else
        {
            shang.transform.localScale = Vector3.one;
        }

        if (kesuofang)
        {
            if (Input.mouseScrollDelta.y < 0)
            {
                if (cam.GetComponent<Camera>().orthographicSize < suoxiaojixian) 
                {
                    cam.GetComponent<Camera>().orthographicSize += Time.deltaTime * 50;
                }
                else
                {
                    cam.GetComponent<Camera>().orthographicSize = suoxiaojixian;
                }
            }

            if (Input.mouseScrollDelta.y > 0)
            {
                if (cam.GetComponent<Camera>().orthographicSize > fangdajixian)
                {
                    cam.GetComponent<Camera>().orthographicSize -= Time.deltaTime * 50;
                }
                else
                {
                    cam.GetComponent<Camera>().orthographicSize = fangdajixian;
                }
            }
        }
    }
}
