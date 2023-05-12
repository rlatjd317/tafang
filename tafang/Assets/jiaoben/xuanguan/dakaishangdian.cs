using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dakaishangdian : MonoBehaviour
{
    Animator anime;
    bool donghuakaishi;
    jiesuo jiaoben;
    public GameObject xutongguan;
    bool yijiesuo;
    tongguan_shuxing tongguan;
    Color qishiyanse;

    private void Start()
    {
        tongguan = GameObject.Find("youxiguanli").GetComponent<cundangdudang>().tongguan;
        anime = xutongguan.GetComponent<Animator>();
        transform.GetComponent<Image>().color = Color.gray;
        Invoke("shezhiyijiesuo", .01f);
    }
    void shezhiyijiesuo()
    {
        for (int i = 0; i < tongguan.shoutonglist.Count; i++)
        {
            if (tongguan.shoutonglist[i] == xutongguan.name)
            {
                yijiesuo = true;
                transform.GetComponent<Image>().color = Color.white;
                break;
            }
        }
    }

    [SerializeField]
    bool donghuakaiqizhuangtai;
    public void dakaifenshushangdian()
    {
        donghuakaiqizhuangtai = false;
        if (yijiesuo)
        {
            SceneManager.LoadScene("fenshushangdian");
        }
        else
        {
            qishiyanse = xutongguan.GetComponent<Image>().color;
            donghuakaiqizhuangtai = anime.enabled;
            if (!donghuakaiqizhuangtai)
            {
                anime.enabled = true;
            }
            anime.SetBool("tishitongguan", true);
            donghuakaishi = true;
        }
    }
    private void Update()
    {
        if (donghuakaishi && !anime.enabled)
        {
            anime.SetBool("tishitongguan", false);
            if (donghuakaiqizhuangtai)
            {
                donghuakaishi = false;
                anime.enabled = true;
            }
            xutongguan.GetComponent<Image>().color = qishiyanse;
        }
    }
}
