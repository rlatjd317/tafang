using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class xiangjiyidong : MonoBehaviour
{
    Camera cam;
    public Vector3 Vector3;
    bool cixu;
    private void Start()
    {
        cam = Camera.main;
    }
    private void OnMouseEnter()
    {
        cixu = true;
    }

    private void OnMouseExit()
    {
        cixu = false;
    }
    private void Update()
    {
        if (cixu)
        {
            cam.transform.position += Vector3 * Time.deltaTime * 3;
        }
    }
}
