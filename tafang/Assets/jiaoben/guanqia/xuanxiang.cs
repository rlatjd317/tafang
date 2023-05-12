using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class xuanxiang : MonoBehaviour
{
    GameObject xuanxianganniu;
    public bool zantingzhong;
    GameObject tishimianban;
    private void Start()
    {
        tishimianban = GameObject.Find("tishimianban");
        tishimianban.transform.localScale = Vector3.zero;
    }
    public void zantingjixu()
    {
        if (!zantingzhong)
        {
            zantingzhong = true;
            transform.GetComponent<Image>().enabled = false;
            transform.Find("jixu").GetComponent<Image>().enabled = true;
            transform.parent.Find("zantingimage").localScale = Vector3.one;
            Time.timeScale = 0;
        }
        else
        {
            zantingzhong = false;
            transform.GetComponent<Image>().enabled = true;
            transform.Find("jixu").GetComponent<Image>().enabled = false;
            transform.parent.Find("zantingimage").localScale = Vector3.zero;
            Time.timeScale = 1;
        }
    }
    public void tanchutishikuang()
    {
        Time.timeScale = 0;
        tishimianban.transform.localScale = Vector3.one;
    }
    public void tishiquxiao()
    {
        Time.timeScale = 1;
        tishimianban.transform.localScale = Vector3.zero;
    }
}
