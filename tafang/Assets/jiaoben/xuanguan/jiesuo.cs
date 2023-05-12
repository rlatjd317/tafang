using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jiesuo : MonoBehaviour
{
    public GameObject xutongguan;
    tongguan_shuxing tongguan;
    public bool yijiesuo;
    private void Start()
    {
        tongguan = GameObject.Find("youxiguanli").GetComponent<cundangdudang>().tongguan;
        jiesuofangfa();
    }
    public void jiesuofangfa()
    {
        if (transform.name != "1") 
        {
            transform.GetComponent<Image>().color = Color.gray;

            for (int i = 0; i < tongguan.shoutonglist.Count; i++)
            {
                if (tongguan.shoutonglist[i] == xutongguan.name)
                {
                    yijiesuo = true;
                    transform.GetComponent<Image>().color = Color.white;
                    transform.Find("liantiao").localScale = Vector3.zero;
                    transform.Find("suo").localScale = Vector3.zero;
                    break;
                }
            }
        }
  
    }
}
