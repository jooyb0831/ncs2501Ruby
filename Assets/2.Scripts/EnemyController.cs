using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator animator;
    [SerializeField] float SPEED = 4.0f;

    public float changeTime = 2.0f;
    [SerializeField] float timer = 1;
    int direction = 1;
    public bool isVertical;

    private Vector2 position;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        position = rb2d.position; 
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;
        if(timer<0)
        {
            direction = -direction;
            timer = changeTime;
        }

       
        if(isVertical)
        {
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", direction);
            position.y += Time.deltaTime * SPEED * direction;
        }
        else
        {
            animator.SetFloat("MoveX", direction);
            animator.SetFloat("MoveY", 0);
            position.x += Time.deltaTime * SPEED * direction;
        }

        rb2d.MovePosition(position);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if(player!=null)
        {
            player.ChangeHealth(-1);
        }
    }
}
