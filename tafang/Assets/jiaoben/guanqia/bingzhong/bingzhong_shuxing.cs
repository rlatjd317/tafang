using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bingzhong_shuxing : MonoBehaviour
{
    public bingzhong_chuangjian bingzhong_chuangjian;

    private void Start()
    {
        Invoke("shuaxingongjifanwei", .01f);
    }
    public void shuaxingongjifanwei()
    {
        bingzhong_gongji jiaoben = GetComponent<bingzhong_gongji>();
        transform.Find("gongjifanwei").localScale =
            new Vector3(jiaoben.gongjifanwei * 2, jiaoben.gongjifanwei * 2, 1);
    }
}
