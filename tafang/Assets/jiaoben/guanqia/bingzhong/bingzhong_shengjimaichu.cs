using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class bingzhong_shengjimaichu : MonoBehaviour
{
    RaycastHit2D dianjibingzhong;
    GameObject bingzhongdianjimianban;
    float shengjijiage;
    float maichujiage;
    float jinbizhi;
    bingzhong_chuangjian chuangjianjiaoben;
    private void Start()
    {
        bingzhongdianjimianban = GameObject.Find("bingzhongdianjimianban");
    }
    bool baochizuobiao;
    private void Update()
    {
        bool jieshu = FindAnyObjectByType<guanqia_jieshu>().jieshu;
        if (jieshu)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            GameObject anniu = EventSystem.current.currentSelectedGameObject;
            if (anniu != null)
            {
                return;
            }

            Vector2 mous_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dianjibingzhong = Physics2D.Raycast(mous_pos, Vector2.zero, 0, LayerMask.GetMask("bingzhong"));
            if (dianjibingzhong.transform != null)
            {
                baochizuobiao = true;
                dianjibingzhong.transform.Find("gongjifanwei").GetComponent<Animator>().enabled = true;

                chuangjianjiaoben = dianjibingzhong.transform.GetComponent<bingzhong_shuxing>().bingzhong_chuangjian;
                shengjijiage = chuangjianjiaoben.ShengjiJiage;

                shuaxinwenben();
            }
            else
            {
                baochizuobiao = false;
                mianbanyincang();
            }
        }
        if (baochizuobiao)
        {
            Vector2 zuobiao = dianjibingzhong.transform.position;
            zuobiao = Camera.main.WorldToScreenPoint(new Vector3(zuobiao.x + .5f, zuobiao.y));
            Vector2 mianbankuandu = bingzhongdianjimianban.GetComponent<RectTransform>().sizeDelta;
            zuobiao = new Vector2(zuobiao.x + mianbankuandu.x / 2, zuobiao.y);
            bingzhongdianjimianban.transform.position = zuobiao;
            bingzhongdianjimianban.transform.localScale = Vector3.one;
        }
    }
    
    void shuaxinwenben()
    {
        int shengjicishu = dianjibingzhong.transform.Find("Canvas/shengjimianban").childCount;
        maichujiage = (chuangjianjiaoben.ChuangjianJiage + shengjijiage * shengjicishu) * .8f;

        GameObject shengji = bingzhongdianjimianban.transform.Find("shengji").gameObject;
        GameObject maichu = bingzhongdianjimianban.transform.Find("maichu").gameObject;
        shengji.transform.Find("wenben").GetComponent<Text>().text = "Éý¼¶(" + shengjijiage.ToString() + ")";
        maichu.transform.Find("wenben").GetComponent<Text>().text = "Âô³ö(" + maichujiage.ToString() + ")";
    }
    public GameObject shengjixing_yuzhijian;
    public void shengjifangfa()
    {
        jinbizhi = FindAnyObjectByType<bingzhongbaifang>().jinbizhi;
        if (jinbizhi >= shengjijiage)
        {
            dianjibingzhong.transform.GetComponent<bingzhong_gongji>().gongjifanwei +=
                dianjibingzhong.transform.GetComponent<bingzhong_gongji>().gongjifanwei * 
                chuangjianjiaoben.shengji_fanwei / 100;

            dianjibingzhong.transform.GetComponent<bingzhong_shuxing>().shuaxingongjifanwei();

            dianjibingzhong.transform.GetComponent<bingzhong_gongji>().gongjipinlv -=
                dianjibingzhong.transform.GetComponent<bingzhong_gongji>().gongjipinlv * 
                chuangjianjiaoben.shengji_pinlv / 100;

            dianjibingzhong.transform.GetComponent<bingzhong_gongji>().gongjisudu +=
                dianjibingzhong.transform.GetComponent<bingzhong_gongji>().gongjisudu * 
                chuangjianjiaoben.shengji_sudu / 100;

            bingzhong_shanghai[] shanghaijiaoben = dianjibingzhong.transform.GetComponentsInChildren<bingzhong_shanghai>();
            for (int i = 0; i < shanghaijiaoben.Length; i++)
            {
                shanghaijiaoben[i].shanghai += shanghaijiaoben[i].shanghai * chuangjianjiaoben.shengji_shanghai / 100;
            }
            FindAnyObjectByType<bingzhongbaifang>().jinbizhi -= shengjijiage;
            FindAnyObjectByType<bingzhongbaifang>().jinbiwenbenshuaxin();

            GameObject shengjimianban = dianjibingzhong.transform.Find("Canvas/shengjimianban").gameObject;
            GameObject fuzhi = Instantiate(shengjixing_yuzhijian, shengjimianban.transform);

            shuaxinwenben();
        }
        else
        {
            FindAnyObjectByType<bingzhongbaifang>().jinbibuzutishi();
        }
    }
    public void maichufangfa()
    {
        FindAnyObjectByType<bingzhongbaifang>().jinbizhi += maichujiage;
        FindAnyObjectByType<bingzhongbaifang>().jinbiwenbenshuaxin();
        dianjibingzhong.transform.parent.GetComponent<baifangdian_shuxing>().yibaifang = false;
        dianjibingzhong.transform.parent.GetComponent<baifangdian_shuxing>().yincangxianshitupian();
        baochizuobiao = false;
        Destroy(dianjibingzhong.transform.gameObject);
        mianbanyincang();
    }
    void mianbanyincang()
    {
        bingzhongdianjimianban.transform.localScale = Vector3.zero;
    }
}
