using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bingzhong_gongji : MonoBehaviour
{
    public float gongjifanwei;
    public float gongjipinlv;
    public float gongjisudu;

    GameObject gongjiCD;
    GameObject gongjiCDditu;
    GameObject shenti;
    GameObject shengjimianban;
    bingzhong_shuxing bingzhong_shuxing;
    private void Start()
    {
        bingzhong_shuxing = transform.GetComponent<bingzhong_shuxing>();

        gongjifanwei = bingzhong_shuxing.bingzhong_chuangjian.GongjiFanwei;
        gongjipinlv = bingzhong_shuxing.bingzhong_chuangjian.GongjiPinlv;
        gongjisudu = bingzhong_shuxing.bingzhong_chuangjian.GongjiSudu;

        gongjiCD = transform.Find("Canvas/gongjiCD").gameObject;
        gongjiCDditu = transform.Find("Canvas/gongjiCDditu").gameObject;
        shenti = transform.Find("zucheng/shenti").gameObject;
        shengjimianban = transform.Find("Canvas/shengjimianban").gameObject;

        shezhiBingzhongCanvas();
    }
    void shezhiBingzhongCanvas()
    {
        gongjiCD.transform.position = Camera.main.WorldToScreenPoint(
            new Vector3(shenti.transform.position.x, shenti.transform.position.y + .55f));
        gongjiCDditu.transform.position = gongjiCD.transform.position;
        shengjimianban.transform.position = Camera.main.WorldToScreenPoint(
            new Vector3(shenti.transform.position.x -.4f, shenti.transform.position.y));
    }

    float jishiqi;
    Animator anime;
    private void Update()
    {
        shezhiBingzhongCanvas();
        jishiqi += Time.deltaTime;
        gongjiCD.transform.GetComponent<Image>().fillAmount = jishiqi / gongjipinlv;
        switch (transform.name)
        {
            case "putongbing":
                putongbing_gongji();
                break;

            case "jianshi":
                anime = GetComponent<Animator>();
                wuqi = transform.Find("jian").gameObject;
                if (!jiluqidian)
                {
                    qidian = wuqi.transform.position;
                    jiluqidian = true;
                }
                jianshi_gongji();
                break;

            case "gongjianshou":
                wuqi = transform.Find("gongjian").gameObject;
                gong = transform.Find("gong").gameObject;
                if (!jiluqidian)
                {
                    qidian = wuqi.transform.position;
                    jiluqidian = true;
                }
                gongjianshou_gongji();
                break;

            case "fashi":
                anime = GetComponent<Animator>();
                //   anime.enabled = false;  //默认关闭
                fashi_gongji();
                break;
        }
    }

    #region 变量
    bool gongjizhong;
    bool fanhuizhong;
    GameObject gongjishou;
    Vector3 fangxiang;
    Vector3 qidian;
    bool jiluqidian;
    bool shezhiwanbi;
    float gongjibanjing;
    float jiaodu;
    GameObject wuqi;
    GameObject gong;
    public bool jizhong;
    GameObject suodingduixiang;
    #endregion
    void putongbing_gongji()
    {
        if (jishiqi >= gongjipinlv && !gongjizhong && !fanhuizhong)
        {
            RaycastHit2D[] hitall = Physics2D.CircleCastAll(
                transform.position, gongjifanwei, Vector2.zero, 0, LayerMask.GetMask("diren"));
            if (hitall.Length > 0)
            {
                GameObject shou1 = transform.Find("zucheng/shou1").gameObject;
                GameObject shou2 = transform.Find("zucheng/shou2").gameObject;
                int suiji = Random.Range(0, 2);

                if (suiji == 0)
                {
                    gongjishou = shou1;
                    fangxiang = hitall[0].transform.position - shou1.transform.position;
                    qidian = shou1.transform.position;
                }
                else if (suiji == 1)
                {
                    gongjishou = shou2;
                    fangxiang = hitall[0].transform.position - shou2.transform.position;
                    qidian = shou2.transform.position;
                }

                gongjishou.transform.up = fangxiang;
                gongjishou.transform.Rotate(0, 0, -180);
                gongjizhong = true;
            }
        }
        if (gongjizhong)
        {
            gongjishou.transform.Translate(fangxiang.normalized * Time.deltaTime * gongjisudu, Space.World);
            RaycastHit2D hit = Physics2D.BoxCast(
                gongjishou.transform.position, gongjishou.GetComponent<BoxCollider2D>().size,
               0, fangxiang, 0, LayerMask.GetMask("diren"));

            //if (hit.collider != null)
            if(jizhong)
            {
                fanhuizhong = true;
                gongjizhong = false;
            }
            else
            {
                var julicha = qidian - gongjishou.transform.position;
                //float gongjifanwei = bingzhong_shuxing.bingzhong_chuangjian.GongjiFanwei;
                if (julicha.sqrMagnitude > gongjifanwei * gongjifanwei)
                {
                    fanhuizhong = true;
                    gongjizhong = false;
                }
            }
        }
        if (fanhuizhong)
        {
            gongjishou.transform.Translate(-fangxiang.normalized * Time.deltaTime * gongjisudu, Space.World);
            var julicha = qidian - gongjishou.transform.position;
            float xiangchafanwei = 0.1f;
            if (julicha.sqrMagnitude < xiangchafanwei * xiangchafanwei)
            {
                gongjishou.transform.position = qidian;
                gongjishou.transform.localRotation = Quaternion.identity;

                fanhuizhong = false;
                jishiqi = 0;
                jizhong = false;
            }
        }
    }

    bool raoquan;
    int quanshu;
    bool jiluraoquan;
    float jishiqi_raoquan;
    void jianshi_gongji()
    {
        if (jishiqi >= gongjipinlv && !fanhuizhong)
        {
            RaycastHit2D[] hitall = Physics2D.CircleCastAll(
                transform.position, gongjifanwei, Vector2.zero, 0, LayerMask.GetMask("diren"));
            if (hitall.Length > 0)
            {
                anime.speed = 1;
                gongjizhong = true;
            }
        }

        if (!gongjizhong && !fanhuizhong)
        {
            anime.enabled = true;
            quanshu = 0;
        }

        if (gongjizhong)
        {
            if (!shezhiwanbi)
            {
                shezhiwanbi = true;
               
                gongjibanjing = gongjifanwei - wuqi.transform.GetComponent<BoxCollider2D>().size.y / 2;
                jiaodu = -1.5f;
            }

            wuqi.transform.Rotate(0, 0, 5);

            if (!raoquan)
            {
                if(!anime.enabled)
                {
                    jishiqi_raoquan += Time.deltaTime * .1f;
                    jiaodu -= Time.deltaTime * gongjisudu;
                    float zuobiaoX = transform.position.x + gongjibanjing * Mathf.Cos(jiaodu);
                    float zuobiaoY = transform.position.y + gongjibanjing * Mathf.Sin(jiaodu);

                    Vector3 mubiaodian = new Vector3(zuobiaoX, zuobiaoY);
                    fangxiang = mubiaodian - wuqi.transform.position;

                    wuqi.transform.position = Vector3.Lerp(wuqi.transform.position, mubiaodian, jishiqi_raoquan * gongjisudu);

                    if (fangxiang.sqrMagnitude <= .05f)
                    {
                        wuqi.transform.position = mubiaodian;
                        raoquan = true;
                        jishiqi_raoquan = 0;
                    }
                }
            }

            if (raoquan)
            {
                jiaodu -= Time.deltaTime * gongjisudu;

                float zuobiaoX = transform.position.x + gongjibanjing * Mathf.Cos(jiaodu);
                float zuobiaoY = transform.position.y + gongjibanjing * Mathf.Sin(jiaodu);
                wuqi.transform.position = new Vector3(zuobiaoX, zuobiaoY);

                Vector2 wuqizuobiao = wuqi.transform.localPosition;
                if (wuqizuobiao.x > 0 && wuqizuobiao.y < 0)
                {
                    if (!jiluraoquan)
                    {
                        jiluraoquan = true;
                    }
                }
                if (jiluraoquan)
                {
                    if (wuqizuobiao.x > 0 && wuqizuobiao.y > 0)
                    {
                        jiluraoquan = false;
                        quanshu++;
                    }
                }

                if (quanshu == 3)
                {
                    Vector3 mubiaodian = new Vector3(transform.position.x + gongjibanjing * Mathf.Cos(45),
                        transform.position.y + gongjibanjing * Mathf.Sin(45));
                    fangxiang = mubiaodian - wuqi.transform.position;
                    if (fangxiang.sqrMagnitude <= .01f)
                    {
                        fanhuizhong = true;
                        gongjizhong = false;
                        shezhiwanbi = false;
                        raoquan = false;
                        wuqi.transform.position = mubiaodian;
                    }
                }
            }
        }

        if (fanhuizhong)
        {
            wuqi.transform.Rotate(0, 0, 5);

            fangxiang = qidian - wuqi.transform.position;
            wuqi.transform.Translate(fangxiang.normalized * Time.deltaTime * gongjisudu, Space.World);
            if (fangxiang.sqrMagnitude <= .05f)
            {
                wuqi.transform.position = qidian;
                wuqi.transform.localRotation = new Quaternion(0, 0, -0.707106829f, 0.707106829f);  // = 0,0,-90
                fanhuizhong = false;
                jishiqi = 0;
            }
        }
    }

    Transform suodingdiren;
    bool suodingzhong;
    float suoding_jishi;
    void gongjianshou_gongji()
    {
        RaycastHit2D[] hitall = Physics2D.CircleCastAll(
                transform.position, gongjifanwei, Vector2.zero, 0, LayerMask.GetMask("diren"));

        if (jishiqi >= gongjipinlv)
        {
            gongjizhong = true;
            suodingzhong = false;
            suoding_jishi = 0;
        }
        else
        {
            if (hitall.Length > 0)
            {
                if (!gongjizhong)
                {
                    if (!suodingzhong)
                    {
                        suodingzhong = true;
                        suodingdiren = hitall[0].transform;
                    }
                    else
                    {
                        suoding_jishi += Time.deltaTime;
                        if (suoding_jishi >= .5f)
                        {
                            suodingzhong = false;
                            suoding_jishi = 0;
                        }
                    }
                    
                    if (suodingdiren != null) //锁定后有可能死亡
                    {
                        fangxiang = suodingdiren.position - transform.position;
                        gong.transform.position = transform.position + fangxiang * .1f;
                        wuqi.transform.position = transform.position + fangxiang * .1f;
                        gong.transform.up = fangxiang;
                        wuqi.transform.up = fangxiang;
                        gong.transform.Rotate(0, 0, 90);
                    }

                }
            }
        }

        if (gongjizhong)
        {
            if (hitall.Length > 0)
            {
                if (!shezhiwanbi)
                {
                    shezhiwanbi = true;
                    
                    fangxiang = hitall[0].transform.position - transform.position;
                    gong.transform.position = transform.position + fangxiang * .1f;
                    wuqi.transform.position = transform.position + fangxiang * .1f;
                    gong.transform.up = fangxiang;
                    wuqi.transform.up = fangxiang;
                    gong.transform.Rotate(0, 0, 90);
                    qidian = wuqi.transform.position;
                    
                }
            }
            if (shezhiwanbi)
            {
                wuqi.transform.Translate(fangxiang.normalized * Time.deltaTime * gongjisudu, Space.World);
                var julicha = transform.position - wuqi.transform.position;
             //   float gongjifanwei = bingzhong_shuxing.bingzhong_chuangjian.GongjiFanwei;
                if (julicha.sqrMagnitude >= gongjifanwei * gongjifanwei)
                {
                    gongjizhong = false;
                    shezhiwanbi = false;
                    wuqi.transform.position = qidian;
                    jishiqi = 0;
                }
            }
        }
    }

    Transform xuanzhongjineng;
    float jishiqi_jineng;
    float jishiqi_jinengpinlv;
    bool zhixingyici;
    void fashi_gongji()
    {
        RaycastHit2D[] hitall = Physics2D.CircleCastAll(
                transform.position, gongjifanwei - .5f, Vector2.zero, 0, LayerMask.GetMask("diren"));
       
        if (jishiqi >= gongjipinlv)
        {
            if (!gongjizhong)
            {
                gongjizhong = true;

                Transform jineng = transform.Find("jineng");
                if (jineng.childCount > 0)
                {
                    int suiji = Random.Range(0, jineng.childCount);
                    xuanzhongjineng = jineng.GetChild(suiji);
                }
            }
        }

        if (hitall.Length > 0 && gongjizhong)
        {
            if (!shezhiwanbi)
            {
                shezhiwanbi = true;
                anime.enabled = true;
                anime.speed = 1;
            }
        }
        if (shezhiwanbi)
        {
            GameObject duixiang = xuanzhongjineng.Find("duixiang").gameObject;
            jineng_shuxing shuxing = xuanzhongjineng.GetComponent<jineng_shuxing>();

            jishiqi_jineng += Time.deltaTime;

            switch (xuanzhongjineng.name)
            {
                case "diaoluowu":
                    if (hitall.Length > 0)
                    {
                        if (jishiqi_jinengpinlv == 0)
                        {
                            int suiji = Random.Range(0, hitall.Length);
                            GameObject fuzhi = Instantiate(duixiang, hitall[suiji].transform).gameObject;
                            Vector3 hitzuobiao = hitall[suiji].transform.position;
                            fuzhi.transform.position = new Vector3(hitzuobiao.x, hitzuobiao.y + 1);
                            fuzhi.transform.localScale = Vector3.one;
                        }

                        jishiqi_jinengpinlv += Time.deltaTime;

                        if (jishiqi_jinengpinlv >= shuxing.pinlv)
                        {
                            jishiqi_jinengpinlv = 0;
                        }
                    }
                    break;

                case "huo":
                    if (!zhixingyici)
                    {
                        zhixingyici = true;
                        duixiang.transform.localScale = Vector3.one;
                        duixiang.transform.position = hitall[0].transform.position;
                    }
                    break;
            }

            if (jishiqi_jineng >= shuxing.chixushijian)
            {
                xuanzhongjineng.Find("duixiang").localScale = Vector3.zero;
                shezhiwanbi = false;
                gongjizhong = false;
                zhixingyici = false;
                jishiqi = 0;
                jishiqi_jineng = 0;
                jishiqi_jinengpinlv = 0;
                anime.speed = 1;
            }
        }
    }
}
