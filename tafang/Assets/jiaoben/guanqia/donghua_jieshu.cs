using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donghua_jieshu : MonoBehaviour
{
    Animator anime;
    private void Start()
    {
        anime = GetComponent<Animator>();
    }
    public void donghuajieshu()
    {
        anime.enabled = false;
    }
    public void donghuazanting()
    {
        anime.speed = 0;
    }
}
