using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bingzhong_jiage : MonoBehaviour
{
    Text jiagewenben;
    List<GameObject> bingzhonglist;
    GameObject bingzhongyuzhijian;
    private void Start()
    {
        jiagewenben = transform.Find("jiagewenben").GetComponent<Text>();
        bingzhonglist = FindAnyObjectByType<bingzhongbaifang>().bingzhong_YuzhijianList;
        Invoke("UIjiagexianshi", .01f);
       // UIjiagexianshi();
    }
    void UIjiagexianshi()
    {
        switch (transform.name)
        {
            case "pugongUI":
                for (int i = 0; i < bingzhonglist.Count; i++)
                {
                    if (bingzhonglist[i].name == "putongbing")
                    {
                        bingzhongyuzhijian = bingzhonglist[i];
                    }
                }
                break;
            case "jianUI":
                for (int i = 0; i < bingzhonglist.Count; i++)
                {
                    if (bingzhonglist[i].name == "jianshi")
                    {
                        bingzhongyuzhijian = bingzhonglist[i];
                    }
                }
                break;
            case "gongjianUI":
                for (int i = 0; i < bingzhonglist.Count; i++)
                {
                    if (bingzhonglist[i].name == "gongjianshou")
                    {
                        bingzhongyuzhijian = bingzhonglist[i];
                    }
                }
                break;
            case "fazhangUI":
                for (int i = 0; i < bingzhonglist.Count; i++)
                {
                    if (bingzhonglist[i].name == "fashi")
                    {
                        bingzhongyuzhijian = bingzhonglist[i];
                    }
                }
                break;
        }
        jiagewenben.text = bingzhongyuzhijian.GetComponent<bingzhong_shuxing>().bingzhong_chuangjian.ChuangjianJiage.ToString();
    }
}
