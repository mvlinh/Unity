using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class holdScript : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] Button PauseButton;
    public Camera minimap;
    private float m_cameraMinSize;
    private float m_cameraMaxSize;
    private float m_cameraSaveSize;
    void Start()
    {
        /* zomm button */
        m_cameraMinSize = 2f;
        m_cameraMaxSize = 12f;
        m_cameraSaveSize = Camera.main.orthographicSize;
        /* zomm button */
        minimap = Camera.main; // scroll
    }
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            minimap.orthographicSize++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            minimap.orthographicSize--;
        }
    }
    public void onPress()
    {
        pausePanel.SetActive(true);
    }

    public void onRelease()
    {
        pausePanel.SetActive(false);
    }
    public void ZoomIn()
    {
        m_cameraSaveSize = Mathf.Clamp(m_cameraSaveSize - 0.5f, m_cameraMinSize, m_cameraMaxSize);
        StartCoroutine(Zoom(-0.025f));
    }

    public void ZoomOut()
    {
        m_cameraSaveSize = Mathf.Clamp(m_cameraSaveSize + 0.5f, m_cameraMinSize, m_cameraMaxSize);
        StartCoroutine(Zoom(0.025f));
    }

    IEnumerator Zoom(float _step)
    {
        while (Mathf.Abs(Camera.main.orthographicSize - m_cameraSaveSize) >= 0.05f)
        {
            yield return new WaitForSeconds(0.005f);
            Camera.main.orthographicSize += _step;
        }

        Camera.main.orthographicSize = m_cameraSaveSize;
    }
}
