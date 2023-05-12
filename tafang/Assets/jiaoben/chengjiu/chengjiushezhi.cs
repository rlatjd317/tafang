using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chengjiushezhi : MonoBehaviour
{
    GameObject shichangmianban;
    GameObject jianzaomianban;
    GameObject gaizaomianban;
    chengjiu chengjiu;
    tongguan_shuxing tongguan;
    [SerializeField]
    float youxishijian;
    int jianzaoshuliang;
    int gaizaocishu;
    Text shichang;
    Text jianzao;
    Text gaizao;
    private void Start()
    {
        shichangmianban = GameObject.Find("shichang/mianban");
        jianzaomianban = GameObject.Find("jianzao/mianban");
        gaizaomianban = GameObject.Find("gaizao/mianban");
        chengjiu = transform.GetComponent<cundangdudang>().chengjiu;
        tongguan = transform.GetComponent<cundangdudang>().tongguan;
        youxishijian = tongguan.youxishijian;
        jianzaoshuliang = tongguan.jianzaoshuliang;
        gaizaocishu = tongguan.gaizaocishu;
        shichang = GameObject.Find("zhi/shichangwenben").GetComponent<Text>();
        jianzao = GameObject.Find("zhi/jianzaowenben").GetComponent<Text>();
        gaizao = GameObject.Find("zhi/gaizaowenben").GetComponent<Text>();
        shichang.text = "��Ϸʱ����" + (youxishijian / 60).ToString("f0") + "����";
        jianzao.text = "����������" + jianzaoshuliang + "��";
        gaizao.text = "���������" + gaizaocishu + "��";

        Invoke("shujubaifang", .01f);
    }
    public GameObject neirong_yuzhijian;
    GameObject fumianban;
    string danwei;
    bool dacheng;

    void shujubaifang()
    {

        for (int i = 0; i < chengjiu.chengjiulist.Count; i++)
        {
            dacheng = false;
            string mingcheng = chengjiu.chengjiulist[i].mingcheng;
            if (mingcheng.Contains("�������"))
            {
                fumianban = gaizaomianban;
                danwei = "��";
                if (gaizaocishu >= chengjiu.chengjiulist[i].shuliang)
                {
                    dacheng = true;
                }
            }
            else if (mingcheng.Contains("��������"))
            {
                fumianban = jianzaomianban;
                danwei = "��";
                if (jianzaoshuliang >= chengjiu.chengjiulist[i].shuliang)
                {
                    dacheng = true;
                }
            }
            else if (mingcheng.Contains("��Ϸʱ��"))
            {
                fumianban = shichangmianban;
                danwei = "����";
                if (youxishijian >= chengjiu.chengjiulist[i].shuliang * 60) 
                {
                    dacheng = true;
                }
            }

            GameObject fuzhi = Instantiate(neirong_yuzhijian, fumianban.transform);
            fuzhi.GetComponent<Text>().text = chengjiu.chengjiulist[i].mingcheng;
            fuzhi.transform.Find("shuliang").GetComponent<Text>().text = chengjiu.chengjiulist[i].shuliang.ToString() + danwei;
            fuzhi.transform.Find("jiangli").GetComponent<Text>().text = chengjiu.chengjiulist[i].jiangli.ToString();
            fuzhi.transform.Find("anniu").GetComponent<anniu_shuxing>().chengjiuchuangjian = chengjiu.chengjiulist[i];

            if (dacheng)
            {
                fuzhi.transform.Find("anniu").localScale = Vector3.one;
            }
            else
            {
                fuzhi.transform.Find("anniu").localScale = Vector3.zero;
            }

            bool yilingqu = chengjiu.chengjiulist[i].yilingqu;
            if (yilingqu)
            {
                fuzhi.transform.Find("anniu").localScale = Vector3.zero;
                fuzhi.GetComponent<Text>().color = new Color(.3f, .3f, .3f);
                fuzhi.transform.Find("shuliang").GetComponent<Text>().color = new Color(.3f, .3f, .3f);
                fuzhi.transform.Find("jiangli").GetComponent<Text>().color = new Color(.3f, .3f, .3f);
            }

        }
    }
}
