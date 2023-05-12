using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shuaguai : MonoBehaviour
{
    public int shuaguaiboshu;
    public float zhunbeishijian;
    public float shuaguaishijian;
    [Tooltip("不填")]
    public int dangqianboshu;

    Text guanqiawenben;
    Text boshuwenben;
    Text jishiqiwenben;
    GameObject direnFuduixiang;
    List<GameObject> shuaguaidianlist = new List<GameObject>();
    GameObject shuaguaiFu;
    guanqia_jieshu guanqia_jieshujiaoben;

    private void Start()
    {
        guanqiawenben = GameObject.Find("guanqiamianban/guanqiawenben").GetComponent<Text>();
        boshuwenben = GameObject.Find("guanqiamianban/boshuwenben").GetComponent<Text>();
        jishiqiwenben = GameObject.Find("guanqiamianban/jishiqiwenben").GetComponent<Text>();
        direnFuduixiang = GameObject.Find("direnFuduixiang");
        shuaguaiFu = GameObject.Find("shuaguai");
        guanqia_jieshujiaoben = transform.GetComponent<guanqia_jieshu>();

     //   shuaguaiboshu = 5;
     //   zhunbeishijian = 5;
     //   shuaguaishijian = 10;
        dangqianboshu = 1;

        shezhishuaguaidian();

        shezhiguanqiamianbanwenben();
    }
    void shezhishuaguaidian()
    {
        Transform[] ziduixiang = shuaguaiFu.GetComponentsInChildren<Transform>();
        for(int i = 1; i < ziduixiang.Length; i++)
        {
            if (ziduixiang[i].name == "shuaguaidian")
            {
                shuaguaidianlist.Add(ziduixiang[i].gameObject);
            }
        }
    }
    void shezhiguanqiamianbanwenben()
    {
        guanqiawenben.text = "第 " + SceneManager.GetActiveScene().name + " 关"; 
        boshuwenben.text = "当前第 " + dangqianboshu + " 波 / 共 " + shuaguaiboshu + " 波";
    }

    bool shuaguaizhong;
    bool jishifuzhi;
    float jishiqi_zhunbei;
    float jishiqi_shuaguai;
    bool shuaguaiwanbi_bool;
    private void Update()
    {
        if (!shuaguaiwanbi_bool)
        {
            if (!jishifuzhi)
            {
                jishifuzhi = true;
                jishiqi_zhunbei = zhunbeishijian;
                jishiqi_shuaguai = shuaguaishijian;
            }

            if (!shuaguaizhong)
            {
                jishiqi_zhunbei -= Time.deltaTime;
                string neirong = jishiqi_zhunbei.ToString("f1");
                jishiqiwenben.text = "准备中： " + neirong;
                if (jishiqi_zhunbei <= 0)
                {
                    shuaguaizhong = true;
                }
            }

            if (shuaguaizhong)
            {
                jishiqi_shuaguai -= Time.deltaTime;
                string neirong = jishiqi_shuaguai.ToString("f1");
                jishiqiwenben.text = "刷怪中：" + neirong;

                shuaguai_kaishi();

                if (jishiqi_shuaguai <= 0)
                {
                    if (dangqianboshu < shuaguaiboshu)
                    {
                        dangqianboshu++;
                        shezhiguanqiamianbanwenben();
                    }
                    else
                    {
                        shuaguaiwanbi_bool = true;
                    }
                    shuaguaizhong = false;
                    jishifuzhi = false;
                    jishiqi_pinlv = 0;
                }
            }
        }
        else
        {
            if (direnFuduixiang.transform.childCount == 0)
            {
                if (!guanqia_jieshujiaoben.jieshu)
                {
                    guanqia_jieshujiaoben.tongguan = true;
                    guanqia_jieshujiaoben.jieshufangfa();
                }
            }
        }
    }

    public GameObject diren_yuzhijian;
    public diren_liebiao liebiao;
    float jishiqi_pinlv;
    void shuaguai_kaishi()
    {
        if (dangqianboshu <= liebiao.liebiao.Count)
        {
            if (jishiqi_pinlv == 0)
            {
                GameObject fuzhiDiren = Instantiate(diren_yuzhijian, direnFuduixiang.transform);
                fuzhiDiren.name = liebiao.liebiao[dangqianboshu - 1].name;
                int shuaguaidiansuoyin = Random.Range(0, shuaguaidianlist.Count);
                fuzhiDiren.transform.position = shuaguaidianlist[shuaguaidiansuoyin].transform.position;
                fuzhiDiren.transform.Find("Canvas").gameObject.SetActive(true);
                fuzhiDiren.GetComponent<diren_yidong>().shuaguaidian = shuaguaidianlist[shuaguaidiansuoyin].gameObject;
                fuzhiDiren.GetComponent<SpriteRenderer>().sprite = liebiao.liebiao[dangqianboshu - 1].Pic;
                fuzhiDiren.GetComponent<SpriteRenderer>().flipX = liebiao.liebiao[dangqianboshu - 1].zuoxiang;
                fuzhiDiren.AddComponent<PolygonCollider2D>();
                fuzhiDiren.GetComponent<PolygonCollider2D>().isTrigger = true;
                fuzhiDiren.GetComponent<diren_shuxing>().diren_chuangjian = liebiao.liebiao[dangqianboshu - 1];
            }

            float shuaguaipinlv = liebiao.liebiao[dangqianboshu - 1].ShuaguaiPinlv;
            jishiqi_pinlv += Time.deltaTime;
            if (jishiqi_pinlv >= shuaguaipinlv)
            {
                jishiqi_pinlv = 0;
            }
        }
    }

}
