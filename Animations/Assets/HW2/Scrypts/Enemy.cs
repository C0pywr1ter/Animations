using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public bool sceneReload;
    
    public float health = 100;
    public bool hit;
    public GameObject _Player;
    public Player player;
    public Rigidbody2D rb;
    public Animator animator;

    public static int enemyDeaths;

    public Vector2 EnemySpawn;

    private void Start()
    {
        

        _Player = GameObject.Find("Player_");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = _Player.GetComponent<Player>();
       
        animator.SetFloat("Enemy", 0);

        EnemySpawn = gameObject.transform.position;
    }
    private void Update()
    {
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
        if(gameObject.transform.position.y <= -19)
        {
            transform.position = EnemySpawn;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && hit == true)
        {
            rb.AddRelativeForce((transform.position - _Player.transform.position) * 150, 0);
            animator.SetFloat("Enemy", -1);
            health--;
          
            //  StartCoroutine(DeathCoroutine());


        }

       else
        {
            animator.SetFloat("Enemy", 0);
              
        }
      
    }







    IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(1.4f);
        enemyDeaths += 1;
        gameObject.SetActive(false);
    }
    IEnumerator ReloadingScene()
    {
        yield return new WaitForSeconds(1);
        sceneReload = false;
    }
}
