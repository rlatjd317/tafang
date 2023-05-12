using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "tongguan", menuName = "zidingyi/tongguan_shuxing")]
public class tongguan_shuxing : ScriptableObject
{
    public List<string> shoutonglist;
    public List<string> wanmeitongguanlist;
    public float fenshu;

    public float youxishijian;
    public int jianzaoshuliang;
    public int gaizaocishu;
}
