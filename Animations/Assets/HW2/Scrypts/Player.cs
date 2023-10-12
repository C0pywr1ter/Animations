using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public Vector2 SpawnPoint;

    private Rigidbody2D rigidbodyMy;
    public Animator animator;

    Vector3 newRotation;

    bool isJump = false;
    public bool isHit = false;
   public  bool isSceneReloading;

    //int enemyKills;
    //Enemy enemy;
    //public GameObject _enemy;

    public TextMeshProUGUI kills;
    public TextMeshProUGUI lifes;

    
    public int HP = 3;
    public int enemyKills;

    public GameObject _Enemy;
    public GameObject _Enemy1;
    public GameObject _Enemy2;
    private List<GameObject> Enemies;
    //private List<Vector2> EnemiesPositions;
  

    public static bool playerIsDead;
    void Start()
    {
       // Enemies = new List<GameObject>() { _Enemy, _Enemy1, _Enemy2 };
       // EnemiesPositions = new List<Vector2>() { EnemySpawn , Enemy1Spawn, Enemy2Spawn };

        SpawnPoint = gameObject.transform.position;

        rigidbodyMy = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //enemy = _enemy.GetComponent<Enemy>();

     //   EnemySpawn = _Enemy.transform.position;
      //  Enemy1Spawn = _Enemy1.transform.position;
       // Enemy2Spawn = _Enemy2.transform.position;


    }

    void Update()
    {
         enemyKills = Enemy.enemyDeaths;
        kills.text = enemyKills.ToString();
        float xAxis = Input.GetAxis("Horizontal");

        lifes.text = HP.ToString();

        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool("Fight", true);
            isHit = true;

        }

        else
        {
            isHit = false;
            animator.SetBool("Fight", false);
        }
        transform.position = transform.position + Vector3.right * xAxis * 0.02f;
        if (xAxis > 0)
        {
            newRotation = new Vector3(0, 0, 0);
            transform.eulerAngles = newRotation;
            animator.SetFloat("Blend", 1);
        }
        if (xAxis < 0)
        {
            newRotation = new Vector3(0, 180, 0);
            transform.eulerAngles = newRotation;
            animator.SetFloat("Blend", 1);
        }
        if (xAxis == 0 & !Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetFloat("Blend", 0);

        }
        if (Input.GetKey(KeyCode.Space))
        {

            if (isJump == false)
            {

                animator.SetFloat("Blend", -1);
                rigidbodyMy.AddRelativeForce(Vector2.up * 25);
                StartCoroutine(JumpCoroutine());
            }

        }

        if (transform.position.y <= -19)
        {
            playerIsDead = true;
            HP--;
            transform.position = SpawnPoint;
        }
        if (HP <=0)
        {
           ReloadPlayerData();
        }
        //else
        //{
        //    isSceneReloading = false;
        //}

        IEnumerator JumpCoroutine()
        {
            yield return new WaitForSeconds(0.2f);
            isJump = true;
            animator.SetFloat("Blend", 0);
            yield return new WaitForSeconds(1);
            isJump = false;

        }

        
    }
    public void ReloadPlayerData()
    {
        isSceneReloading = true;
        transform.position = SpawnPoint;
    
          HP = 3;
        for(int i = 0; i < 3; i++)
        {
            //Instantiate(Enemies[i], EnemiesPositions[i], Quaternion.identity);
           Debug.Log(i);
          Enemies[i].SetActive(true);
          
        }

    }
}
