using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    const float SPEED = 40f;
    public int maxHealth = 5;
    public int currentHealth;
    public int Health { get { return currentHealth; } }
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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

        /*GetAxisRaw를 사용하면 -1,0,1값만 넘어옴
        float vertical = Input.GetAxisRaw("Vertical");
        Debug.Log($"h:{horizontal}");
        Debug.Log($"v:{vertical}");
        */
        Vector2 position = rb2d.position;
        position.x += SPEED * horizontal * Time.deltaTime;
        position.y += SPEED * vertical * Time.deltaTime;
        rb2d.MovePosition(position);


    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log($"{currentHealth}/{maxHealth}");
    }
}
