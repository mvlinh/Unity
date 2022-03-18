using UnityEngine;
using UnityEngine.UI;


public class LevelTimer : MonoBehaviour
{
    public float timer = 10f;
    public float speed = 1f;

    private Slider m_Slider;
    private GameObject player;
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
        if (timer > 0f)
        {
            timer -= speed * Time.deltaTime;
            m_Slider.value = timer;
        }
        else
        {
            Destroy(player);
            GetComponent<GamePlayUI>().PlayerDied();
        }
    }
    void GetPrefereces()
    {
        player = GameObject.Find("Player");
        m_Slider = GameObject.Find("Time slider").GetComponent<Slider>();

        m_Slider.minValue = 0f;
        m_Slider.maxValue = timer;
        m_Slider.value = m_Slider.maxValue;

    }
}
