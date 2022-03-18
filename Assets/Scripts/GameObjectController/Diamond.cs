using UnityEngine;

public class Diamond : MonoBehaviour
{
    void Start()
    {
       
        if (Door.instance != null)
        {
            Door.instance.colletableCount++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameTag.Player))
        {
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject);
            if(Door.instance != null)
            {
                GamePlayUI.Instance.SetText();
                Door.instance.DecrementCollectables();
            }
        }
    }
}
