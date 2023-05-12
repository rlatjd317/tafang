using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guanqia_shuxing : MonoBehaviour
{
    public float guanqia_xueliang;
    GameObject xuetiao;
    GameObject xuetiaowenben;
    public float qishixueliang;
    

    public float youxishijian;
    public int jianzaoshuliang;
    public bool youxishijian_jishikaishi;
    public float shadishu;


    private void Start()
    {
        youxishijian_jishikaishi = true;
        xuetiao = GameObject.Find("jidixueliang/xuetiao").gameObject;
        xuetiaowenben = GameObject.Find("jidixueliang/wenben").gameObject;
        qishixueliang = guanqia_xueliang;

        xueliangshuaxin();
    }

    public void xueliangshuaxin()
    {
        xuetiao.GetComponent<Image>().fillAmount = guanqia_xueliang / qishixueliang;
        xuetiaowenben.GetComponent<Text>().text = guanqia_xueliang.ToString() + " / " + qishixueliang;
        panduanyouxijieshu();
    }
    void panduanyouxijieshu()
    {
        if (guanqia_xueliang <= 0)
        {
            FindAnyObjectByType<guanqia_jieshu>().jieshufangfa();
        }
    }
    private void Update()
    {
        if (youxishijian_jishikaishi)
        {
            youxishijian += Time.deltaTime;
        }
    }
}
