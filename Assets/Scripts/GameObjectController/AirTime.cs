using UnityEngine;
public class AirTime : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (gameObject.name == "Air")
            {
                GamePlayUI.Instance.Air.AddTime(10);
               //AirScript.air += 10f;
            }
           
        }
        Destroy(gameObject);
    }
}
