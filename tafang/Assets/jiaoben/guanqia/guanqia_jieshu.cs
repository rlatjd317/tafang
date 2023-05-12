using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class guanqia_jieshu : MonoBehaviour
{
    public bool jieshu;
    public bool tongguan;
    GameObject jieshumianban;
    Text shadiwenben;
    Text tongguanwenben;
    Text shoutongwenben;
    Text hejiwenben;

    float tongguanfenshu;
    float shoutongfenshu;
    cundangdudang sljiaoben;

    private void Start()
    {
        jieshumianban = GameObject.Find("jieshumianban");
        shadiwenben = jieshumianban.transform.Find("shadiwenben").GetComponent<Text>();
        tongguanwenben = jieshumianban.transform.Find("tongguanwenben").GetComponent<Text>();
        shoutongwenben = jieshumianban.transform.Find("shoutongwenben").GetComponent<Text>();
        hejiwenben = jieshumianban.transform.Find("hejiwenben").GetComponent<Text>();

        sljiaoben = transform?.GetComponent<cundangdudang>();
    }

    bool shoutong;
    bool wanmeitongguan;
    public void jieshufangfa()
    {
        jieshu = true;
        guanqia_shuxing guanqiashuxingjiaoben = transform.GetComponent<guanqia_shuxing>();
        guanqiashuxingjiaoben.youxishijian_jishikaishi = false;

        Animator anime = jieshumianban.GetComponent<Animator>();
        anime.enabled = true;

        string dangqianguanqia = SceneManager.GetActiveScene().name;

        float shadishu = guanqiashuxingjiaoben.shadishu;
        shadiwenben.text = "杀敌：" + shadishu;
        if (tongguan)
        {
            tongguanfenshu = 50;

            tongguanwenben.text = "通关：" + tongguanfenshu.ToString("f0");
            shoutong = true;
            if (sljiaoben.tongguan.shoutonglist.Contains(dangqianguanqia))
            {
                shoutong = false;
            }

            if (shoutong)
            {
                shoutongfenshu = 1000;

                sljiaoben.tongguan.shoutonglist.Add(dangqianguanqia);
                shoutongwenben.text = "首通：" + shoutongfenshu.ToString("f0");
            }
            else
            {
                shoutongfenshu = 0;
                shoutongwenben.text = "";
            }
        }
        else
        {
            tongguanfenshu = 0;

            tongguanwenben.text = "";
            shoutongwenben.text = "";
        }

        hejiwenben.text = "合计：" + (shadishu + tongguanfenshu + shoutongfenshu).ToString();
        tongguan = false;
        sljiaoben.tongguan.fenshu += shadishu + tongguanfenshu + shoutongfenshu;

        float qishixueliang = guanqiashuxingjiaoben.qishixueliang;
        float guanqiaxueliang = guanqiashuxingjiaoben.guanqia_xueliang;
        if (guanqiaxueliang == qishixueliang)
        {
            wanmeitongguan = true;
            if (sljiaoben.tongguan.wanmeitongguanlist.Contains(dangqianguanqia))
            {
                wanmeitongguan = false;
            }

            if (wanmeitongguan)
            {
                sljiaoben.tongguan.wanmeitongguanlist.Add(dangqianguanqia);
            }
        }
        sljiaoben.tongguan.youxishijian += guanqiashuxingjiaoben.youxishijian;
        sljiaoben.tongguan.jianzaoshuliang += guanqiashuxingjiaoben.jianzaoshuliang;
        sljiaoben.tongguanCundang();

    }
}
