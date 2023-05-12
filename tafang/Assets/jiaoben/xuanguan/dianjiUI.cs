using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dianjiUI : MonoBehaviour
{
    GameObject xuanzhongkuang;
    GameObject guanqianeirongmianban;
    private void Start()
    {
        xuanzhongkuang = GameObject.Find("xuanzhongkuang");
        guanqianeirongmianban = GameObject.Find("gudingHuabu/guanqianeirongmianban");
        guanqianeirongmianban.transform.localScale = Vector3.zero;
    }
    RaycastHit2D dianjiduixiang;
    GameObject dangqianduixiang;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject anniu = EventSystem.current.currentSelectedGameObject;
            if (anniu != null)
            {
                return;
            }

            Camera cam = Camera.main;
            Vector2 mos = cam.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, -cam.transform.localPosition.z));

            dianjiduixiang = Physics2D.Raycast(mos, Vector2.zero, 0, LayerMask.GetMask("xuanguan/guanqiaUI"));

            if (dangqianduixiang != null)
            {
                dangqianduixiang.transform.GetComponent<Animator>().enabled = false;
                dangqianduixiang.transform.GetComponent<jiesuo>().jiesuofangfa();

                dangqianduixiang.transform.localScale = Vector3.one;
                dangqianduixiang.transform.localRotation = Quaternion.identity;
                dangqianduixiang = null;
            }

            if (dianjiduixiang.transform != null)
            {
                dangqianduixiang = dianjiduixiang.transform.gameObject;
                dianjiduixiang.transform.GetComponent<Animator>().enabled = true;
                xuanzhongkuang.transform.position = dianjiduixiang.transform.position;
                xuanzhongkuang.transform.localScale = Vector3.one;
                xuanzhongkuang.transform.SetParent(dangqianduixiang.transform);
                dianjiduixiang.transform.localScale = new Vector3(1.2f, 1.2f, 1);
                xianshishuxingmianban();
            }
            else
            {
                xuanzhongkuang.transform.localScale = Vector3.zero;
                xuanzhongkuang.transform.localRotation = Quaternion.identity;
                xuanzhongkuang.transform.SetParent(GameObject.Find("shijieHuabu").transform);
                guanqianeirongmianban.transform.localScale = Vector3.zero;
            }
        }

        if (tishidonghuakaishi && !anime_tishi.enabled)
        {
            anime_tishi.SetBool("tishitongguan", false);
            jiaoben.xutongguan.GetComponent<jiesuo>().jiesuofangfa();
        }
    }
    public tongguan_shuxing tongguanshuxing;
    bool weishoutong;
    bool weiwantong;

    void xianshishuxingmianban()
    {
        guanqianeirongmianban.transform.localScale = Vector3.one;
        GameObject guanqiaming = guanqianeirongmianban.transform.Find("guanqiaming").gameObject;
        guanqiaming.GetComponent<Text>().text = "关卡：" + dianjiduixiang.transform.name;
        guanqiaming.GetComponent<Text>().color = Color.white;

        GameObject shoutong = guanqianeirongmianban.transform.Find("shoutong").gameObject;
        weishoutong = true;
        for (int i = 0; i < tongguanshuxing.shoutonglist.Count; i++) 
        {
            
            if (dianjiduixiang.transform.name == tongguanshuxing.shoutonglist[i])
            {
                weishoutong = false;
                break;
            }
        }
        if(weishoutong)
        {
            shoutong.GetComponent<Text>().text = "未首通";
            shoutong.GetComponent<Text>().color = Color.black;
        }
        else
        {
            shoutong.GetComponent<Text>().text = "已首通";
            shoutong.GetComponent<Text>().color = Color.white;
        }

        GameObject wantong = guanqianeirongmianban.transform.Find("wantong").gameObject;
        weiwantong = true;
        for (int i = 0; i < tongguanshuxing.wanmeitongguanlist.Count; i++)
        {
            if (dianjiduixiang.transform.name == tongguanshuxing.wanmeitongguanlist[i])
            {
                weiwantong = false;
                break;
            }
        }
        if (weiwantong)
        {
            wantong.GetComponent<Text>().text = "未完美通关";
            wantong.GetComponent<Text>().color = Color.black;
        }
        else
        {
            wantong.GetComponent<Text>().text = "已完美通关";
            wantong.GetComponent<Text>().color = Color.white;
        }
    }
    bool tishidonghuakaishi;
    Animator anime_tishi;
    jiesuo jiaoben;
    public void youxikaishi()
    {
        if (dianjiduixiang.transform.name == "1")
        {
            SceneManager.LoadScene(dianjiduixiang.transform.name);
        }
        else
        {
            jiaoben = dianjiduixiang.transform.GetComponent<jiesuo>();
            if (jiaoben.yijiesuo)
            {
                SceneManager.LoadScene(dianjiduixiang.transform.name);
            }
            else
            {
                anime_tishi = jiaoben.xutongguan.GetComponent<Animator>();
                anime_tishi.enabled = true;
                anime_tishi.SetBool("tishitongguan", true);
                tishidonghuakaishi = true;
            }
        }
    }
    public void chengjiuchangjing()
    {
        SceneManager.LoadScene("chengjiu");
    }
}
