using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class shangdian : MonoBehaviour
{
    public tongguan_shuxing tongguan_shuxing;
    Text zongfen;
    GameObject xuanzekuang;
    GameObject xuanze;
    GameObject jiajian;
    GameObject leixing;
    GameObject dengji;
    GameObject gaizaofen;
    GameObject heji;
    GameObject shuxingmianban;
    GameObject baocungenggaimianban;


    private void Start()
    {
        zongfen = GameObject.Find("zongfen").GetComponent<Text>();
        zongfenshuaxin();
        xuanzekuang = GameObject.Find("xuanzekuang");
        xuanzekuang.transform.localScale = Vector3.zero;
        xuanze = GameObject.Find("gaizaomianban/xuanze");
        xuanze.transform.localScale = Vector3.zero;
        jiajian = GameObject.Find("jiajian");
        jiajian.transform.localScale = Vector3.zero;
        leixing = GameObject.Find("gaizaomianban/xiangxi/leixing");
        dengji = GameObject.Find("gaizaomianban/xiangxi/dengji");
        gaizaofen = GameObject.Find("gaizaomianban/xiangxi/gaizaofen");
        heji = GameObject.Find("gaizaomianban/heji");
        shuxingmianban = GameObject.Find("shuxingmianban");
        baocungenggaimianban = GameObject.Find("baocungenggaimianban");

    }
    void zongfenshuaxin()
    {
        zongfen.text = "分数：" + tongguan_shuxing.fenshu.ToString();
    }
    RaycastHit2D dianji;
    [Header("不填")]
    bingzhong_chuangjian bingzhongchuangjian;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject anniu = EventSystem.current.currentSelectedGameObject;
            if (anniu != null)
            {
                return;
            }

            Vector2 mos = Input.mousePosition;
            dianji = Physics2D.Raycast(mos, Vector2.zero, 0, LayerMask.GetMask("fenshu/shuxingUI"));
            if (dianji.transform != null)
            {
                string bingzhongname = dianji.transform.parent.GetComponent<bingzhongshezhi>().bingzhongname;
                List<bingzhong_chuangjian> list = dianji.transform.parent.GetComponent<bingzhongshezhi>().bingzhonglist;
                for (int i = 0; i < list.Count; i++) 
                {
                    if (list[i].name == bingzhongname)
                    {
                        bingzhongchuangjian = list[i];
                    }
                }

                xuanzekuang.transform.position = dianji.transform.position;
                xuanzekuang.transform.localScale = Vector3.one;
                shezhigaizao_xuanze();
                jiajian.transform.position = new Vector3(dianji.transform.position.x + 200, dianji.transform.position.y);
                jiajian.transform.localScale = Vector3.one;
            }
            else
            {
                xuanzekuang.transform.localScale = Vector3.zero;
                xuanze.transform.localScale = Vector3.zero;
                jiajian.transform.localScale = Vector3.zero;
            }
        }
    }

    void shezhigaizao_xuanze()
    {
        xuanze.transform.localScale = Vector3.one;
        Text xuanzeshuxing = xuanze.transform.Find("xuanzeshuxing").GetComponent<Text>();
        Text gaizaohoushuxing = xuanze.transform.Find("gaizaohoushuxing").GetComponent<Text>();
        Text gaizaofen = xuanze.transform.Find("gaizaofen").GetComponent<Text>();
        switch (dianji.transform.name)
        {
            case "gongjifanwei":
                xuanzeshuxing.text = "攻击范围：" + bingzhongchuangjian.GongjiFanwei.ToString("f1");
                gaizaohoushuxing.text = "+" + bingzhongchuangjian.gaizao_fanwei.ToString("f1");
                gaizaofen.text = "需要分数：" + bingzhongchuangjian.gaizao_fanweiFen.ToString();
                break;
            case "gongjipinlv":
                xuanzeshuxing.text = "攻击频率：" + bingzhongchuangjian.GongjiPinlv.ToString("f1");
                gaizaohoushuxing.text = "+" + bingzhongchuangjian.gaizao_pinlv.ToString("f1");
                gaizaofen.text = "需要分数：" + bingzhongchuangjian.gaizao_pinlvFen.ToString();
                break;
            case "gongjisudu":
                xuanzeshuxing.text = "攻击速度：" + bingzhongchuangjian.GongjiSudu.ToString("f1");
                gaizaohoushuxing.text = "+" + bingzhongchuangjian.gaizao_sudu.ToString("f1");
                gaizaofen.text = "需要分数：" + bingzhongchuangjian.gaizao_suduFen.ToString();
                break;
            case "shanghai":
                xuanzeshuxing.text = "伤害：" + bingzhongchuangjian.Shanghai.ToString("f1");
                gaizaohoushuxing.text = "+" + bingzhongchuangjian.gaizao_shanghai.ToString("f1");
                gaizaofen.text = "需要分数：" + bingzhongchuangjian.gaizao_shanghaiFen.ToString();
                break;
            case "chuangjianjiage":
                xuanzeshuxing.text = "创建价格：" + bingzhongchuangjian.ChuangjianJiage.ToString();
                gaizaohoushuxing.text = "" + bingzhongchuangjian.gaizao_chuangjianjiage.ToString();
                gaizaofen.text = "需要分数：" + bingzhongchuangjian.gaizao_chuangjianjiageFen.ToString();
                break;
            case "shengjijiage":
                xuanzeshuxing.text = "升级价格：" + bingzhongchuangjian.ShengjiJiage.ToString();
                gaizaohoushuxing.text = "" + bingzhongchuangjian.gaizao_shengjijiage.ToString();
                gaizaofen.text = "需要分数：" + bingzhongchuangjian.gaizao_shengjijiageFen.ToString();
                break;
            case "shengjifanwei":
                xuanzeshuxing.text = "升级范围：" + bingzhongchuangjian.shengji_fanwei.ToString();
                gaizaohoushuxing.text = "+" + bingzhongchuangjian.gaizao_shengji_fanwei.ToString();
                gaizaofen.text = "需要分数：" + bingzhongchuangjian.gaizao_shengji_fanweiFen.ToString();
                break;
            case "shengjipinlv":
                xuanzeshuxing.text = "升级频率：" + bingzhongchuangjian.shengji_pinlv.ToString();
                gaizaohoushuxing.text = "+" + bingzhongchuangjian.gaizao_shengji_pinlv.ToString();
                gaizaofen.text = "需要分数：" + bingzhongchuangjian.gaizao_shengji_pinlvFen.ToString();
                break;
            case "shengjisudu":
                xuanzeshuxing.text = "升级速度：" + bingzhongchuangjian.shengji_sudu.ToString();
                gaizaohoushuxing.text = "+" + bingzhongchuangjian.gaizao_shengji_sudu.ToString();
                gaizaofen.text = "需要分数：" + bingzhongchuangjian.gaizao_shengji_suduFen.ToString();
                break;
            case "shengjishanghai":
                xuanzeshuxing.text = "升级伤害：" + bingzhongchuangjian.shengji_shanghai.ToString();
                gaizaohoushuxing.text = "+" + bingzhongchuangjian.gaizao_shengji_shanghai.ToString();
                gaizaofen.text = "需要分数：" + bingzhongchuangjian.gaizao_shengji_shanghaiFen.ToString();
                break;
        }
    }
    public bool yougaidong;
    public void jiahao()
    {
        dianji.transform.GetComponent<jiajian>().jiajianshu++;
        shuaxinxiangxi();
        yougaidong = true;
    }
    public void jianhao()
    {
        jiajian jiajian = dianji.transform.GetComponent<jiajian>();
        if (jiajian.jiajianshu > 0)
        {
            jiajian.jiajianshu--;
            shuaxinxiangxi();
        }
    }
    public GameObject neirong_yuzhijian;

    float hejifen;
    float gaizaofenshu;
    void shuaxinxiangxi()
    {
        qingchuziduixiang();
        hejifen = 0;
        Transform[] ziduixiang = shuxingmianban.GetComponentsInChildren<Transform>();
        for (int i = 2; i < ziduixiang.Length; i++) //    i = 2    父对象, mingcheng, 除外
        {
            int jiajian = ziduixiang[i].GetComponent<jiajian>().jiajianshu;
            if (jiajian > 0)
            {
                GameObject fuzhi = Instantiate(neirong_yuzhijian, leixing.transform);
                GameObject fuzhi1 = Instantiate(neirong_yuzhijian, dengji.transform);
                GameObject fuzhi2 = Instantiate(neirong_yuzhijian, gaizaofen.transform);
                fuzhi.name = ziduixiang[i].name;
                fuzhi1.name = ziduixiang[i].name;
                fuzhi2.name = ziduixiang[i].name;
                switch (ziduixiang[i].name)
                {
                    case "gongjifanwei":
                        fuzhi.GetComponent<Text>().text = "攻击范围";
                        gaizaofenshu = bingzhongchuangjian.gaizao_fanweiFen;
                        break;
                    case "gongjipinlv":
                        fuzhi.GetComponent<Text>().text = "攻击频率";
                        gaizaofenshu = bingzhongchuangjian.gaizao_pinlvFen;
                        break;
                    case "gongjisudu":
                        fuzhi.GetComponent<Text>().text = "攻击速度";
                        gaizaofenshu = bingzhongchuangjian.gaizao_suduFen;
                        break;
                    case "shanghai":
                        fuzhi.GetComponent<Text>().text = "伤害";
                        gaizaofenshu = bingzhongchuangjian.gaizao_shanghaiFen;
                        break;
                    case "chuangjianjiage":
                        fuzhi.GetComponent<Text>().text = "创建价格";
                        gaizaofenshu = bingzhongchuangjian.gaizao_chuangjianjiageFen;
                        break;
                    case "shengjijiage":
                        fuzhi.GetComponent<Text>().text = "升级价格";
                        gaizaofenshu = bingzhongchuangjian.gaizao_shengjijiageFen;
                        break;
                    case "shengjifanwei":
                        fuzhi.GetComponent<Text>().text = "升级范围";
                        gaizaofenshu = bingzhongchuangjian.gaizao_shengji_fanweiFen;
                        break;
                    case "shengjipinlv":
                        fuzhi.GetComponent<Text>().text = "升级频率";
                        gaizaofenshu = bingzhongchuangjian.gaizao_shengji_pinlvFen;
                        break;
                    case "shengjisudu":
                        fuzhi.GetComponent<Text>().text = "升级速度";
                        gaizaofenshu = bingzhongchuangjian.gaizao_shengji_suduFen;
                        break;
                    case "shengjishanghai":
                        fuzhi.GetComponent<Text>().text = "升级伤害";
                        gaizaofenshu = bingzhongchuangjian.gaizao_shengji_shanghaiFen;
                        break;
                }
                fuzhi1.GetComponent<Text>().text = jiajian.ToString();
                fuzhi2.GetComponent<Text>().text = (jiajian * gaizaofenshu).ToString();
                hejifen += jiajian * gaizaofenshu;
            }
        }
        if (hejifen > 0)
        {
            heji.GetComponent<Text>().text = "合计：" + hejifen.ToString();
        }
        else
        {
            heji.GetComponent<Text>().text = "合计";
        }
    }
    void qingchuziduixiang()
    {
        Transform[] shanchu = leixing.GetComponentsInChildren<Transform>();
        for (int i = 1; i < shanchu.Length; i++)
        {
            Destroy(shanchu[i].gameObject);
        }
        Transform[] shanchu1 = dengji.GetComponentsInChildren<Transform>();
        for (int i = 1; i < shanchu1.Length; i++)
        {
            Destroy(shanchu1[i].gameObject);
        }
        Transform[] shanchu2 = gaizaofen.GetComponentsInChildren<Transform>();
        for (int i = 1; i < shanchu2.Length; i++)
        {
            Destroy(shanchu2[i].gameObject);
        }
    }
    int gaizaocishu;
    public void gaizaoanniu()
    {
        if (tongguan_shuxing.fenshu >= hejifen)
        {
            Transform[] ziduixiang = shuxingmianban.GetComponentsInChildren<Transform>();
            for (int i = 2; i < ziduixiang.Length; i++) //    i = 2    父对象, mingcheng, 除外
            {
                int jiajianshu = ziduixiang[i].GetComponent<jiajian>().jiajianshu;
                gaizaocishu += jiajianshu;
                if (jiajianshu > 0)
                {
                    switch (ziduixiang[i].name)
                    {
                        case "gongjifanwei":
                            for (int j = 0; j < jiajianshu; j++)
                            {
                                bingzhongchuangjian.GongjiFanwei += bingzhongchuangjian.gaizao_fanwei;
                            }
                            break;
                        case "gongjipinlv":
                            for (int j = 0; j < jiajianshu; j++)
                            {
                                bingzhongchuangjian.GongjiPinlv += bingzhongchuangjian.gaizao_pinlv;
                            }
                            break;
                        case "gongjisudu":
                            for (int j = 0; j < jiajianshu; j++)
                            {
                                bingzhongchuangjian.GongjiSudu += bingzhongchuangjian.gaizao_sudu;
                            }
                            break;
                        case "shanghai":
                            for (int j = 0; j < jiajianshu; j++)
                            {
                                bingzhongchuangjian.Shanghai += bingzhongchuangjian.gaizao_shanghai;
                            }
                            break;
                        case "chuangjianjiage":
                            for (int j = 0; j < jiajianshu; j++)
                            {
                                bingzhongchuangjian.ChuangjianJiage += bingzhongchuangjian.gaizao_chuangjianjiage;
                            }
                            break;
                        case "shengjijiage":
                            for (int j = 0; j < jiajianshu; j++)
                            {
                                bingzhongchuangjian.ShengjiJiage += bingzhongchuangjian.gaizao_shengjijiage;
                            }
                            break;
                        case "shengjifanwei":
                            for (int j = 0; j < jiajianshu; j++)
                            {
                                bingzhongchuangjian.shengji_fanwei += bingzhongchuangjian.gaizao_shengji_fanwei;
                            }
                            break;
                        case "shengjipinlv":
                            for (int j = 0; j < jiajianshu; j++)
                            {
                                bingzhongchuangjian.shengji_pinlv += bingzhongchuangjian.gaizao_shengji_pinlv;
                            }
                            break;
                        case "shengjisudu":
                            for (int j = 0; j < jiajianshu; j++)
                            {
                                bingzhongchuangjian.shengji_sudu += bingzhongchuangjian.gaizao_shengji_sudu;
                            }
                            break;
                        case "shengjishanghai":
                            for (int j = 0; j < jiajianshu; j++)
                            {
                                bingzhongchuangjian.shengji_shanghai += bingzhongchuangjian.gaizao_shengji_shanghai;
                            }
                            break;
                    }
                }
            }

            bingzhongshezhi shezhi = FindAnyObjectByType<bingzhongshezhi>();
            
            shezhi.shezhiwenben();
            tongguan_shuxing.fenshu -= hejifen;
            tongguan_shuxing.gaizaocishu += gaizaocishu;
            transform.GetComponent<cundangdudang>().tongguanCundang();
            zongfenshuaxin();

            quxiaoanniu();

            transform.GetComponent<cundangdudang>().bingzhongCundang(bingzhongchuangjian.name);
        }
        else
        {
            zongfen.transform.GetComponent<Animator>().enabled = true;
        }
    }
    public void quxiaoanniu()
    {
        Transform[] ziduixiang = shuxingmianban.GetComponentsInChildren<Transform>();
        for (int i = 2; i < ziduixiang.Length; i++) //    i = 2    父对象, mingcheng, 除外
        {
            ziduixiang[i].GetComponent<jiajian>().jiajianshu = 0;
        }
        shuaxinxiangxi();
        yougaidong = false;
        baocungenggaimianban.transform.localScale = Vector3.zero;
        gaizaocishu = 0;
    }
}
