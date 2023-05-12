using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diaoluowu : MonoBehaviour
{
    Rigidbody2D rig;
    bool diaoluozhong;
    SpriteRenderer sp;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        if (transform.parent.gameObject.layer == LayerMask.NameToLayer("diren"))
        {
            diaoluozhong = true;
            rig.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    bool pengzhuang;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (diaoluozhong && collision.transform == transform.parent)
        {
            transform.parent = null;
            float suijizuoyou = Random.Range(-4f, 4f);
            float suijigaodu = Random.Range(2f, 5f);
            rig.velocity = new Vector2 (suijizuoyou, suijigaodu);
            diaoluozhong = false;
            pengzhuang = true;
            transform.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    float jishiqi;
    private void Update()
    {
        jishiqi += Time.deltaTime;
        if (pengzhuang)
        {
            Color color = sp.color;
            float colorA = sp.color.a;
            colorA -= Time.deltaTime;
            sp.color = new Color(color.r, color.g, color.b, colorA);
        }
        else
        {
            if (diaoluozhong && jishiqi >= 3)
            {
                Destroy(gameObject);
            }
        }

        if (sp.color.a < 0f) 
        {
            Destroy(gameObject);
        }
    }
}
