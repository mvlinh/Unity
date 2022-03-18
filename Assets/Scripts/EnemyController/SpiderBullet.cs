using UnityEngine;

public class SpiderBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag(GameTag.Player))
        {
           GameController.Instance.DestroyPlayer();
            Destroy(gameObject);
            GamePlayUI.Instance.PlayerDied();
        }
        if(target.tag == GameTag.Ground)
        {
            Destroy (gameObject);
        }
    }
}
