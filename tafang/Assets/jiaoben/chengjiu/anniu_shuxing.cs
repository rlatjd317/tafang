using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class anniu_shuxing : MonoBehaviour
{
    public chengjiu_chuangjian chengjiuchuangjian;
    tongguan_shuxing tongguan;
    cundangdudang sl;
    public void dianjianniu()
    {
        sl = GameObject.Find("youxiguanli").GetComponent<cundangdudang>();
        float jiangli = float.Parse(transform.parent.Find("jiangli").GetComponent<Text>().text);
        tongguan = sl.tongguan;
        tongguan.fenshu += jiangli;
        chengjiuchuangjian.yilingqu = true;
        transform.localScale = Vector3.zero;
        transform.parent.GetComponent<Text>().color = new Color(.3f, .3f, .3f);
        transform.parent.Find("shuliang").GetComponent<Text>().color = new Color(.3f, .3f, .3f);
        transform.parent.Find("jiangli").GetComponent<Text>().color = new Color(.3f, .3f, .3f);
        sl.tongguanCundang();
        sl.chengjiuCundang();
    }
}
