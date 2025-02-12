using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    private Vector2 position;
    private Rigidbody2D rb2d;
    const float SPEED = 4.0f;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    public int maxHealth = 5;
    public int currentHealth;
    public int Health { get { return currentHealth; } }

    private Animator animator;
    private Vector2 lookDirection = new Vector2(1,0);


    [SerializeField] GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        position = rb2d.position;
        currentHealth = maxHealth;
        /*
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 10;// 초당 프레임 10으로 제한
        */
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal, vertical);
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(0.0f,move.y)) //Approximately거의 동일하면 true반환함.
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
        /*GetAxisRaw를 사용하면 -1,0,1값만 넘어옴
        float vertical = Input.GetAxisRaw("Vertical");
        Debug.Log($"h:{horizontal}");
        Debug.Log($"v:{vertical}");
        
        
        position.x += SPEED * horizontal * Time.deltaTime;
        position.y += SPEED * vertical * Time.deltaTime;
        */
        position += move * SPEED * Time.deltaTime;
        rb2d.MovePosition(position);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if(invincibleTimer<0)
            {
                isInvincible = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
    }

    public void ChangeHealth(int amount)
    {
        if(amount<0)
        {
            if(isInvincible)
            {
                return;
            }
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log($"{currentHealth}/{maxHealth}");
    }

    private void Launch()
    {
        GameObject projectileObj = Instantiate(projectilePrefab, rb2d.position + Vector2.up * 0.5f, Quaternion.identity);
        Projectile projectile = projectileObj.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);
        animator.SetTrigger("Launch");
    }
}
