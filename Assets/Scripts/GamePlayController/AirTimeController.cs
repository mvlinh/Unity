using UnityEngine;
using UnityEngine.UI;

public class AirTimeController : MonoBehaviour
{
    public float air = 10f;
    public float speed = 1f;

    private Slider m_Slider;
    private Player player;
    private void Awake()
    {
        GetPrefereces();
    }  
    void Update()
    {
        if (!player)
        {
            return;
        }
        if(air > 0f)
        {
            air -= speed*Time.deltaTime;
            m_Slider.value = air;
        }
        else
        {
            Destroy(player);
            GetComponent<GamePlayUI>().PlayerDied();
        }
    }
    void GetPrefereces()
    {
        player = Player.Instance;
        m_Slider = GameObject.Find("Air slider").GetComponent<Slider>();

        m_Slider.minValue = 0f;
        m_Slider.maxValue = air;
        m_Slider.value = m_Slider.maxValue;

    }
}
