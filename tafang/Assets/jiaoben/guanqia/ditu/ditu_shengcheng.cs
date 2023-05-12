using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ditu_shengcheng : MonoBehaviour
{
    float zuo;
    float you;
    float shang;
    float xia;
    public ditu_huacaoliebiao huacaoliebiao;
    private void Start()
    {
        shezhifanwei();
        shengchengsuijihuacao();
    }
    void shezhifanwei()
    {
        zuo = -1.1f;
        you = 1.1f;
        shang = .7f;
        xia = -.7f;
    }
    public GameObject huacao_yuzhijian;
    void shengchengsuijihuacao()
    {
        int suijizhonglei = Random.Range(7, huacaoliebiao.huacaolist.Count);
        for(int i = 0; i < suijizhonglei; i++)
        {
            int suijiyuansu = Random.Range(0, huacaoliebiao.huacaolist.Count);
            int fuzhishu = Random.Range(2, 7);
            for (int j = 0; j < fuzhishu; j++)
            {
                GameObject fuzhi = Instantiate(huacao_yuzhijian, transform);
                fuzhi.transform.localPosition = new Vector3(Random.Range(zuo, you), Random.Range(shang, xia));
                fuzhi.GetComponent<SpriteRenderer>().sprite = huacaoliebiao.huacaolist[suijiyuansu];
                int zhengfan = Random.Range(0, 2);
                if (zhengfan == 0)
                {
                    fuzhi.GetComponent<SpriteRenderer>().flipX = true;
                }
            }
        }
    }
}
