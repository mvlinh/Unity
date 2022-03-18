using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private bool moveable;
    private Vector3 dir;
    private Rigidbody2D rib;

    private void Start()
    {
        rib = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (moveable)
        {
            Move();
        }
    }

    public void Active(Vector3 dir)
    {
        moveable = true;
        this.dir = dir;
    }
    private void Move()
    {
        transform.position += dir * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == GameTag.Enemy)
        {
            Destroy(target.gameObject);
            Destroy(gameObject);
        }
        if (target.tag == GameTag.Ground)
        {
            Destroy(gameObject);
        }
    }
}
