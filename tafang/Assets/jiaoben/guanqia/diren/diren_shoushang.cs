using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class diren_shoushang : MonoBehaviour
{
    float shanghai;
    public GameObject diaoxue_yuzhijian;
    diren_shuxing diren_shuxing;
    float qishixueliang;
    GameObject xuetiao;
    GameObject xuetiaoditu;

    private void Start()
    {
        diren_shuxing = GetComponent<diren_shuxing>();
        qishixueliang = diren_shuxing.diren_chuangjian.Xueliang;
        xuetiao = transform.Find("Canvas/xuetiao").gameObject;
        xuetiaoditu = transform.Find("Canvas/xuetiaoditu").gameObject;

        xuetiao.GetComponent<Image>().fillAmount = diren_shuxing.Xueliang / qishixueliang;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("wuqi"))
        {
            shanghai = collision.GetComponent<bingzhong_shanghai>().shanghai;
            if (collision.transform.name == "shou1" || collision.transform.name == "shou2")
            {
                collision.transform.parent.parent.GetComponent<bingzhong_gongji>().jizhong = true;
            }
            panduanshoushang();
        }
    }

    bool diaoxuexiaoguo;
    bool siwangxiaoguo;
    bool shoushangwudi;
    void panduanshoushang()
    {
        if (!shoushangwudi)
        {
            diren_shuxing.Xueliang -= shanghai;
            GameObject fuzhi = Instantiate(diaoxue_yuzhijian, transform);
            fuzhi.GetComponent<TextMesh>().text = shanghai.ToString("f0");
            fuzhi.transform.position = transform.position;
            xuetiao.GetComponent<Image>().fillAmount = diren_shuxing.Xueliang / qishixueliang;
            if (diren_shuxing.Xueliang > 0)
            {
                diaoxuexiaoguo = true;
            }
            else
            {
                siwangxiaoguo = true;
                FindAnyObjectByType<bingzhongbaifang>().jinbizhi += diren_shuxing.diren_chuangjian.jinbi;
                FindAnyObjectByType<bingzhongbaifang>().jinbiwenbenshuaxin();
            }
        }
    }
    float jishiqi_diaoxue;
    float jishiqi_siwang;
    private void Update()
    {
        Vector3 zuobiao = Camera.main.WorldToScreenPoint(
            new Vector3(transform.position.x, transform.position.y + .6f));
        xuetiao.transform.position = zuobiao;
        xuetiaoditu.transform.position = zuobiao;   

        if (diaoxuexiaoguo)
        {
            jishiqi_diaoxue += Time.deltaTime;

            SpriteRenderer sp = GetComponent<SpriteRenderer>();
            sp.color = Color.red;

            shoushangwudi = true;

            if (jishiqi_diaoxue >= .5f)
            {
                shoushangwudi = false;

                sp.color = Color.white;
                jishiqi_diaoxue = 0;
                diaoxuexiaoguo = false;
            }
        }

        if (siwangxiaoguo)
        {
            transform.GetComponent<PolygonCollider2D>().enabled = false;
            jishiqi_siwang += Time.deltaTime;
            transform.localScale = new Vector3(1 - jishiqi_siwang, 1 - jishiqi_siwang);
            if (transform.localScale.x < 0)
            {
                Destroy(gameObject);
                FindAnyObjectByType<guanqia_shuxing>().shadishu++;
            }
        }
    }
}
