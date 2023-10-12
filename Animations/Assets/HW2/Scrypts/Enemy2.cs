using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
  
    public int jumpForce = 200;
    public float timer;
    public Transform PlayerTransform;
    public float time;
    private void FixedUpdate()
    {

    }

    private void Update()
    {
        timer += Time.deltaTime ;

        if (timer >= 2f)
        {
            animator.SetFloat("Enemy", 3);
          
          
            rb.AddRelativeForce(new Vector2(0, 65));
           
            if (gameObject.transform.position.x - _Player.transform.position.x <= 8)
            {
          

                transform.position = Vector2.MoveTowards(transform.position, PlayerTransform.position, 2 * Time.deltaTime);
                
            }
           
            if (timer >= 2.5f)
            {
               
                timer = 0;
                animator.SetFloat("Enemy", 0);
            }
           
        }



        sceneReload = player.isSceneReloading;
        hit = player.isHit;
        if (health <= 0)
        {
            animator.SetFloat("Enemy", -2);
            StartCoroutine(DeathCoroutine());
            health = 100;

        }
        if (sceneReload)
        {

            enemyDeaths = 0;
            StartCoroutine(ReloadingScene());
        }
        if (gameObject.transform.position.y <= -19)
        {
            transform.position = EnemySpawn;
        }

    }

    /* private void OnTriggerStay2D(Collider2D collision)
     {
         if (collision.gameObject.tag == "Player" && hit == true)
         {
             rb.AddRelativeForce((transform.position - Player.transform.position) * 150, 0);
             animator.SetFloat("Enemy", -1);
             health--;

             //  StartCoroutine(DeathCoroutine());


         }


         {
             animator.SetFloat("Enemy", 0);
         }
         if(collision.gameObject.tag == "Ground")
         {
             timer = 0;
         }
     }
    */








    IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(1.4f);
        Enemy.enemyDeaths ++;
        gameObject.SetActive(false);
    }
    IEnumerator ReloadingScene()
    {
        yield return new WaitForSeconds(1);
        sceneReload = false;
    }
}
