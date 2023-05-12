using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bingzhongbaifang : MonoBehaviour
{
    public List<GameObject> bingzhong_YuzhijianList = new List<GameObject>();
    GameObject baifangFuduixiang;
    Text jinbiwenben;
    public float jinbizhi;
    Camera maincam;
    private void Start()
    {
        baifangFuduixiang = GameObject.Find("baifangFuduixiang");
        jinbiwenben = GameObject.Find("jinbi").GetComponent<Text>();
        jinbiwenbenshuaxin();

        baifangdianshezhi();
        maincam = Camera.main;
    }

    public void jinbiwenbenshuaxin()
    {
        jinbiwenben.text = "½ð±Ò£º " + jinbizhi;
    }

    RaycastHit2D bingzhongUIHit;
    RaycastHit2D baifangdianHit;
    GameObject bingzhong_Yuzhijian;
    GameObject tuodongImage;
    bool shubiaoanzhu;
    GameObject fuzhiwu;
    private void Update()
    {
        bool jieshu = FindAnyObjectByType<guanqia_jieshu>().jieshu;
        if (jieshu)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            bool zantingzhong = FindAnyObjectByType<xuanxiang>().zantingzhong;
            if (zantingzhong)
            {
                return;
            }
            shubiaoanzhu = true;
            Vector3 mos_pos = Input.mousePosition;
            bingzhongUIHit = Physics2D.Raycast(mos_pos, Vector2.zero, 0, LayerMask.GetMask("bingzhongUI"));
            if (bingzhongUIHit.transform != null)
            {
                switch (bingzhongUIHit.transform.name)
                {
                    case "pugongUI":
                        for (int i = 0; i < bingzhong_YuzhijianList.Count; i++)
                        {
                            if (bingzhong_YuzhijianList[i].name == "putongbing")
                            {
                                bingzhong_Yuzhijian = bingzhong_YuzhijianList[i];
                            }
                        }
                        break;
                    case "jianUI":
                        for (int i = 0; i < bingzhong_YuzhijianList.Count; i++)
                        {
                            if (bingzhong_YuzhijianList[i].name == "jianshi")
                            {
                                bingzhong_Yuzhijian = bingzhong_YuzhijianList[i];
                            }
                        }
                        break;
                    case "gongjianUI":
                        for (int i = 0; i < bingzhong_YuzhijianList.Count; i++)
                        {
                            if (bingzhong_YuzhijianList[i].name == "gongjianshou")
                            {
                                bingzhong_Yuzhijian = bingzhong_YuzhijianList[i];
                            }
                        }
                        break;
                    case "fazhangUI":
                        for (int i = 0; i < bingzhong_YuzhijianList.Count; i++)
                        {
                            if (bingzhong_YuzhijianList[i].name == "fashi")
                            {
                                bingzhong_Yuzhijian = bingzhong_YuzhijianList[i];
                            }
                        }
                        break;
                }

                if (jinbizhi >= bingzhong_Yuzhijian.GetComponent<bingzhong_shuxing>().bingzhong_chuangjian.ChuangjianJiage)
                {
                    Transform huabu = GameObject.Find("MainHuabu").transform;
                    tuodongImage = Instantiate(bingzhongUIHit.transform.GetChild(0).gameObject, huabu);
                    baifangkuangxianshi();
                }
                else
                {
                    jinbibuzutishi();
                    bingzhong_Yuzhijian = null;
                }
            }
            else
            {
                bingzhong_Yuzhijian = null;
            }
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mos_pos = maincam.ScreenToWorldPoint(Input.mousePosition);

            baifangdianHit = Physics2D.Raycast(mos_pos, Vector2.zero, 0, LayerMask.GetMask("baifangdian"));
            if (baifangdianHit.transform != null)
            {
                if (bingzhong_Yuzhijian != null)
                {
                    if (!baifangdianHit.transform.GetComponent<baifangdian_shuxing>().yibaifang)
                    {
                        fuzhiwu = Instantiate(bingzhong_Yuzhijian, baifangdianHit.transform);
                        fuzhiwu.name = bingzhong_Yuzhijian.name;
                        baifangdianHit.transform.GetComponent<baifangdian_shuxing>().yibaifang = true;
                        baifangdianHit.transform.GetComponent<baifangdian_shuxing>().yincangxianshitupian();
                        jinbizhi -= bingzhong_Yuzhijian.GetComponent<bingzhong_shuxing>().bingzhong_chuangjian.ChuangjianJiage;
                        FindAnyObjectByType<guanqia_shuxing>().jianzaoshuliang++;
                        bingzhong_shanghai[] shanghaijiaoben = fuzhiwu.GetComponentsInChildren<bingzhong_shanghai>();
                        for (int i = 0; i < shanghaijiaoben.Length; i++)
                        {
                            shanghaijiaoben[i].shanghai = fuzhiwu.GetComponent<bingzhong_shuxing>().bingzhong_chuangjian.Shanghai;
                        }

                        jinbiwenbenshuaxin();
                    }
                }
            }
            Destroy(tuodongImage);
            baifangkuangyincang();
            shubiaoanzhu = false;
        }

        if (shubiaoanzhu)
        {
            if (tuodongImage != null)
            {
                tuodongImage.transform.position = Input.mousePosition;
            }
        }
    }
    public void jinbibuzutishi()
    {
        Animator anime = jinbiwenben.transform.GetComponent<Animator>();
        anime.enabled = true;
    }
    List<Transform> baifangdianList = new List<Transform>();
    void baifangdianshezhi()
    {
        baifangdianList.Clear();
        Transform[] ziduixiang = baifangFuduixiang.GetComponentsInChildren<Transform>();
        for (int i = 0; i < ziduixiang.Length; i++)
        {
            if (ziduixiang[i].name == "baifangdian")
            {
                baifangdianList.Add(ziduixiang[i]);
            }
        }
    }
    void baifangkuangxianshi()
    {
        for (int i = 0; i < baifangdianList.Count; i++)
        {
            if (!baifangdianList[i].GetComponent<baifangdian_shuxing>().yibaifang)
            {
                baifangdianList[i].transform.Find("biankuang").localScale = Vector3.one;
            }
        }
    }
    void baifangkuangyincang()
    {
        for (int i = 0; i < baifangdianList.Count; i++)
        {
            baifangdianList[i].transform.Find("biankuang").localScale = Vector3.zero;
        }
    }
}
