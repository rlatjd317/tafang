using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diren_shuxing : MonoBehaviour
{
    public diren_chuangjian diren_chuangjian;
    public float Xueliang;
    private void Start()
    {
        Xueliang = diren_chuangjian.Xueliang;
    }
}
