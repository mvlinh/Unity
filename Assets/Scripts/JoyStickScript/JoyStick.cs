using UnityEngine;
using UnityEngine.EventSystems;

public partial class JoyStick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] bool isleft;
    private Player player;

    void Start()
    {
        player = GameController.Instance.Player;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        player.SetMoveLeft(isleft);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        player.StopMoving();
    }
}
