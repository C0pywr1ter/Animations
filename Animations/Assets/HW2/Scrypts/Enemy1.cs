using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    public Transform PlayerTransform;
    private void FixedUpdate()
    {
        if (gameObject.transform.position.x - _Player.transform.position.x <= 8)
        {

           
            transform.position = Vector2.MoveTowards(transform.position, PlayerTransform.position, 2 * Time.deltaTime);

        }
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
        if (gameObject.transform.position.y <= -19)
        {
            transform.position = EnemySpawn;
        }
    }
    IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(1.4f);
        Enemy.enemyDeaths++;
        gameObject.SetActive(false);
    }
    IEnumerator ReloadingScene()
    {
        yield return new WaitForSeconds(1);
        sceneReload = false;
    }
}
