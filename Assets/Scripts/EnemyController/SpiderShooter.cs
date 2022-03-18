using System.Collections;
using UnityEngine;

public class SpiderShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    public Transform firePoint;
    void Start()
    {
        StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(2, 7));
        Instantiate(bullet,firePoint.position, Quaternion.identity);
        StartCoroutine(Attack());
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.CompareTag(GameTag.Player))
        {
            GameController.Instance.DestroyPlayer();

            GamePlayUI.Instance.PlayerDied();
        }
    }
}
