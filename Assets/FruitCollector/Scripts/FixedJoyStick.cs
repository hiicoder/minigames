using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedJoyStick : MonoBehaviour
{
    public RectTransform backGround;
    public RectTransform handle;
    [Range(0f, 2f)] public float HandleLimit = 1f;
    public Vector2 input = Vector2.zero;
    
    
}
