using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInputController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    Vector3 initialPoint;
    Vector3 finalPoint;
    public SnakeBehaviour _snake;

    public void OnBeginDrag(PointerEventData eventData)
    {
        initialPoint = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        finalPoint = eventData.position;
        Vector3 comandVector = finalPoint - initialPoint;
        float module = comandVector.sqrMagnitude;
        float sinVector = Vector3.Dot(comandVector, Vector3.up) / module;
        float cosVector = Vector3.Dot(comandVector, Vector3.right) / module;

        if (sinVector > 0 && Mathf.Abs(sinVector) > Mathf.Abs(cosVector))
        {
            _snake._direction = Vector2.up;
        }
        else if (sinVector < 0 && Mathf.Abs(sinVector) > Mathf.Abs(cosVector))
        {
            _snake._direction = Vector2.down;
        }
        else if (cosVector > 0 && Mathf.Abs(sinVector) < Mathf.Abs(cosVector))
        {
            _snake._direction = Vector2.right;
        }
        else if (cosVector < 0 && Mathf.Abs(sinVector) < Mathf.Abs(cosVector))
        {
            _snake._direction = Vector2.left;
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
       
    }
}
