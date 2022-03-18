using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float MinX, MaxX;

    private Transform player;
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    void Update()
    {
        if (player != null)
        {
            Vector3 temp = transform.position;
            temp.x = player.position.x;
            if(temp.x < MinX)
            {
                temp.x = MinX;
            }
            if (temp.x > MaxX)
            {
                temp.x = MaxX;
            }
            transform.position = temp;
        }
    }
}
