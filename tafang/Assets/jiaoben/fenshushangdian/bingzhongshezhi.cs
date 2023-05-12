using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class bingzhongshezhi : MonoBehaviour
{
    public List<bingzhong_chuangjian> bingzhonglist;
    [Header("²»Ìî")] //
    public string bingzhongname;
    [Header("²»Ìî")] //
    bingzhong_chuangjian bingzhong;
    Text mingcheng;
    Text gongjifanwei;
    Text gongjipinlv;
    Text gongjisudu;
    Text shanghai;
    Text chuangjianjiage;
    Text shengjijiage;
    Text shengjifanwei;
    Text shengjipinlv;
    Text shengjisudu;
    Text shengjishanghai;
    GameObject shuxingmianban;
    RaycastHit2D dianjibingzhong;

    Text gaizao_mingcheng;

    GameObject baocungenggaimianban;


    private void Start()
    {
        shuxingmianban = GameObject.Find("shuxingmianban");
        shuxingmianban.transform.localScale = Vector3.zero;

        gaizao_mingcheng = GameObject.Find("gaizaomianban/mingcheng").GetComponent<Text>();

        shezhizujian();
        baocungenggaimianban = GameObject.Find("baocungenggaimianban");
        baocungenggaimianban.transform.localScale = Vector3.zero;
    }
    void shezhizujian()
    {
        mingcheng = transform.Find("mingcheng").GetComponent<Text>();
        gongjifanwei = transform.Find("gongjifanwei").GetComponent<Text>();
        gongjipinlv = transform.Find("gongjipinlv").GetComponent<Text>();
        gongjisudu = transform.Find("gongjisudu").GetComponent<Text>();
        shanghai = transform.Find("shanghai").GetComponent<Text>();
        chuangjianjiage = transform.Find("chuangjianjiage").GetComponent<Text>();
        shengjijiage = transform.Find("shengjijiage").GetComponent<Text>();
        shengjifanwei = transform.Find("shengjifanwei").GetComponent<Text>();
        shengjipinlv = transform.Find("shengjipinlv").GetComponent<Text>();
        shengjisudu = transform.Find("shengjisudu").GetComponent<Text>();
        shengjishanghai = transform.Find("shengjishanghai").GetComponent<Text>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dianjibingzhong = Physics2D.Raycast(mos, Vector3.zero, 0, LayerMask.GetMask("bingzhong"));
            if (dianjibingzhong.transform != null)
            {
                bingzhongname = dianjibingzhong.transform.name;

                if (bingzhong == null)
                {
                    shezhibingzhong();
                    shezhishuxingmianban();
                }
                else
                {
                    if (bingzhong.name != bingzhongname && FindAnyObjectByType<shangdian>().yougaidong)
                    {
                        baocungenggaimianban.transform.localScale = Vector3.one;
                    }
                    else
                    {
                        shezhibingzhong();
                        shezhishuxingmianban();
                    }
                }
            }
        }
    }
    void shezhibingzhong()
    {
        for (int i = 0; i < bingzhonglist.Count; i++)
        {
            if (dianjibingzhong.transform.name == bingzhonglist[i].name)
            {
                bingzhong = bingzhonglist[i];
                break;
            }
        }
    }
    void shezhishuxingmianban()
    {
        Vector3 UIzuobiao = Camera.main.WorldToScreenPoint(dianjibingzhong.transform.position);
        shuxingmianban.transform.position =
            new Vector3(UIzuobiao.x, shuxingmianban.transform.position.y);
        shuxingmianban.transform.localScale = Vector3.one;

        gaizao_mingcheng.text = bingzhong.Name;

        shezhiwenben();
    }

    public void shezhiwenben()
    {
        mingcheng.text = bingzhong.Name;
        gongjifanwei.text = "¹¥»÷·¶Î§£º" + bingzhong.GongjiFanwei.ToString("f1");
        gongjipinlv.text = "¹¥»÷ÆµÂÊ£º" + bingzhong.GongjiPinlv.ToString("f1");
        gongjisudu.text = "¹¥»÷ËÙ¶È£º" + bingzhong.GongjiSudu.ToString("f1");
        shanghai.text = "ÉËº¦£º" + bingzhong.Shanghai.ToString("f1");
        chuangjianjiage.text = "´´½¨¼Û¸ñ£º" + bingzhong.ChuangjianJiage.ToString();
        shengjijiage.text = "Éý¼¶¼Û¸ñ£º" + bingzhong.ShengjiJiage.ToString();
        shengjifanwei.text = "Éý¼¶·¶Î§£º" + bingzhong.shengji_fanwei.ToString();
        shengjipinlv.text = "Éý¼¶ÆµÂÊ£º" + bingzhong.shengji_pinlv.ToString();
        shengjisudu.text = "Éý¼¶ËÙ¶È£º" + bingzhong.shengji_sudu.ToString();
        shengjishanghai.text = "Éý¼¶ÉËº¦£º" + bingzhong.shengji_shanghai.ToString();
    }
}
