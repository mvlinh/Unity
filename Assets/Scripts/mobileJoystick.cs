using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class mobileJoystick : MonoBehaviour
{
    private RectTransform joystickTransform;
    [SerializeField] private float dragthreshold = 0.6f;
    [SerializeField] private int dragMovementDistance = 30;
    private int dragOffSetDistance = 100;
}
