// CRIANDO A PARTE DE CONTROLE DO MORCEGO.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public float attackTime;
    public Transform player;


    void Start()
    {
        attackTime = 0;
    }


    void Update()
    {
        if (GetComponent<Character>().life <= 0)
        {
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 2;
            this.enabled = false;
        }

        if (Vector2.Distance(transform.position, player.GetComponent<CapsuleCollider2D>().bounds.center) > 0.9f)
        {
            attackTime = 0;
            transform.position = Vector2.MoveTowards(transform.position, player.GetComponent<CapsuleCollider2D>().bounds.center, 3f * Time.deltaTime);
        }
        else
        {
            attackTime = attackTime + Time.deltaTime;
            if(attackTime >= 0.6)
            {
                attackTime = 0;
                player.GetComponent<Character>().PlayerDamage(1);
            }
        }
    }
}

//CRIANDO A PARTE DE COLISÃO DE ATAQUE DO MORCEGO AO PLAYER PASSAR POR ELE.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTrigger : MonoBehaviour
{

    public Transform[] bat;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach(Transform obj in bat)
            {
                obj.GetComponent<BatController>().enabled = true;
            }
        }
    }
}
