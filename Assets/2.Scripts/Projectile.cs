using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public AudioClip bulletAud;
    public AudioClip fixAud;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        if(rb2d == null)
        {
            rb2d = GetComponent<Rigidbody2D>();
        }
        rb2d.AddForce(direction * force);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if(e!=null)
        {
            e.Fix();
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.magnitude > 1000f)
        {
            Destroy(gameObject);
        }
    }
}
