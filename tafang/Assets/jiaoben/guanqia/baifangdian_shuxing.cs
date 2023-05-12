using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baifangdian_shuxing : MonoBehaviour
{
    public bool yibaifang;
    SpriteRenderer sp;
    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }
    public void yincangxianshitupian()
    {
        if (yibaifang)
        {
            sp.enabled = false;
        }
        else
        {
            sp.enabled = true;
        }
    }
}
