using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb2d;

    [SerializeField] float SPEED = 15f;

    public float changeTime = 3.0f;
    [SerializeField] float timer = 1;
    int direction = 1;
    public bool isVertical;

    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.one * -1; 
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

        Vector2 position = rb2d.position;

        if(isVertical)
        {
            position.y += Time.deltaTime * SPEED * direction;
        }
        else
        {
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
