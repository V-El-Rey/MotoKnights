using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Action onButtonDown;
    public Action onButtonUp;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        onButtonDown?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       onButtonUp?.Invoke();
    }
}
