using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "chengjiu", menuName = "zidingyi/chengjiu")]
public class chengjiu : ScriptableObject
{
    public List<chengjiu_chuangjian> chengjiulist;
}

[System.Serializable]
public class chengjiu_chuangjian
{
    public string mingcheng;
    public float shuliang;
    public float jiangli;
    public bool yilingqu;
}
