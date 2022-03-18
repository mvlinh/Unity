using System.Collections;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float force = 700f;
    public string bouncy = "bouncy";
    public string TPlayer = "Player";
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    IEnumerator AnimateBouncy()
    {
        anim.SetBool(bouncy, true);
        yield return new WaitForSeconds(1.7f);
        anim.SetBool(bouncy, false);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == TPlayer)
        {
            collision.gameObject.GetComponent<Player>().BouncePlayerWithBouncy(force);
            StartCoroutine(AnimateBouncy());
        }
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == TPlayer)
    //    {
    //        collision.gameObject.GetComponent<Player>().BouncePlayerWithBouncy(force);
    //        StartCoroutine(AnimateBouncy());
    //    }
    //}
}

