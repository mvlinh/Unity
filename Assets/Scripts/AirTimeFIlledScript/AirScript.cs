using UnityEngine;
using UnityEngine.UI;

public class AirScript : MonoBehaviour
{

    private float air;
    public float maxAir = 50f;
    public float speed = 1f;

    public Image airBar;
    private void Start()
    {
        air = maxAir;
    }
    private void Update()
    {
        AirBarfilled();
        if (air > 0)
        {
            air -= speed*Time.deltaTime;
        }
        else
        {
            GameController.Instance.DestroyPlayer();
            GamePlayUI.Instance.PlayerDied();
        }
    }
    void AirBarfilled()
    {
        airBar.fillAmount = air / maxAir;
    }

    public void AddTime(float value)
    {
        air += value;
    }

}
