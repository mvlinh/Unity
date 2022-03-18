using System.Collections;
using UnityEngine;

public class SpiderJumper : MonoBehaviour
{
    public float forceY = 300f;

    private Rigidbody2D Mybody;
    private Animator anim;
    private void Awake()
    {
        Mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
    void Start()
    {
        StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(2, 7));
        forceY = Random.Range(250f, 500f);
        Mybody.AddForce(new Vector2(0, forceY));
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(.7f); 
        StartCoroutine(Attack());
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.CompareTag(GameTag.Player))
        {
            GamePlayUI.Instance.PlayerDied();
            GameController.Instance.DestroyPlayer();

        }
        if (target.CompareTag(GameTag.Ground))
        {
            anim.SetBool("Attack", false);
        }
    }
}
