using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class diren_yidong : MonoBehaviour
{
    float yidongsudu;
    int dangqianboshu;
    [Header("²»Ìî")]
    public GameObject shuaguaidian;
    Transform lujing;
    Vector3 zhongdian;
    diren_shuxing diren_shuxing;
    bool feixing;
    private void Start()
    {
        dangqianboshu = FindAnyObjectByType<shuaguai>().dangqianboshu;
        diren_shuxing = transform.GetComponent<diren_shuxing>();
        yidongsudu = diren_shuxing.diren_chuangjian.Yidongsudu;
        lujing = shuaguaidian.transform.Find("lujing").transform;
        zhongdian = GameObject.Find("shuaguai/zhongdian").transform.position;
        feixing = transform.GetComponent<diren_shuxing>().diren_chuangjian.feixing;
    }
    Vector3 mubiaodian;
    Transform mubiaozujian;
    bool shezhizuobiao;
    private void Update()
    {
        if (feixing)
        {
            shezhizuobiao = true;
            mubiaodian = zhongdian;
        }
        else
        {
            if (transform.position == shuaguaidian.transform.position)
            {
                if (!shezhizuobiao)
                {
                    if (lujing.childCount > 0)
                    {
                        shezhizuobiao = true;
                        int suiji = Random.Range(0, lujing.childCount);
                        mubiaozujian = lujing.GetChild(suiji).transform.Find("daodafanwei").transform;
                        mubiaodian = mubiaozujian.position;
                    }
                    else
                    {
                        shezhizuobiao = true;
                        mubiaodian = zhongdian;
                        mubiaozujian = null;
                    }
                }
            }
            else if (shezhizuobiao && transform.position == mubiaodian)
            {
                shezhizuobiao = false;
                if (mubiaozujian != null)
                {
                    int zizujianshu = mubiaozujian.parent.childCount;
                    if (zizujianshu > 1)
                    {
                        shezhizuobiao = true;
                        int suiji = Random.Range(1, zizujianshu);
                        mubiaozujian = mubiaozujian.parent.GetChild(suiji).transform.Find("daodafanwei").transform;
                        mubiaodian = mubiaozujian.position;
                    }
                    else if (zizujianshu == 1)
                    {
                        shezhizuobiao = true;
                        mubiaodian = zhongdian;
                    }
                }
            }
        }

        if (shezhizuobiao)
        {
            transform.position = Vector3.MoveTowards(transform.position, mubiaodian, yidongsudu * Time.deltaTime);
        }

        if (transform.position == zhongdian)
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x - Time.deltaTime,
                    transform.localScale.y - Time.deltaTime, 0);
            }
            else
            {
                guanqia_jieshu jiaoben = FindAnyObjectByType<guanqia_jieshu>();
                if (!jiaoben.jieshu)
                {
                    FindAnyObjectByType<guanqia_shuxing>().guanqia_xueliang -= diren_shuxing.diren_chuangjian.Shanghai;
                    FindAnyObjectByType<guanqia_shuxing>().xueliangshuaxin();
                }
                Destroy(gameObject);
            }
            transform.GetComponent<PolygonCollider2D>().enabled = false;
            transform.Find("Canvas").gameObject.SetActive(false);
        }
    }
}
