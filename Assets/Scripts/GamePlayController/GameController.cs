using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] Player player;
    public bool hack;
    private static GameController instance;
    public static GameController Instance => instance;
    public int Level;
    public Player Player => player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void DestroyPlayer()
    {
        if (hack)
            return;

        if (player != null)
        {
            Destroy(player.gameObject);

        }
    }

}
