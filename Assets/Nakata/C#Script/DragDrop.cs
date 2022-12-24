using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] GameObject key;
    private Vector2 prePosition;

    /// <summary>
    /// �h���b�O�J�n���ɌĂяo�����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        prePosition = transform.position;
    }

    /// <summary>
    /// �h���b�O���ɌĂяo�����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    /// <summary>
    /// �h���b�O�I���ɌĂяo�����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        bool flg = true;

        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);

        foreach (var hit in raycastResults)
        {
            if (hit.gameObject.CompareTag("image"))
            {
                transform.position = hit.gameObject.transform.position;
                flg = false;
                Destroy(this.gameObject);
                Destroy(GameObject.Find("Image"));
                Destroy(GameObject.Find("backrest"));
                Destroy(GameObject.Find("leg3"));

                key.SetActive(true);
            }
        }

        if (flg)
        {
            transform.position = prePosition;
        }
    }

}