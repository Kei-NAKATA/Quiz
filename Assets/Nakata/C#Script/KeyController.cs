using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyController : MonoBehaviour
{
    [SerializeField] GameObject clear;
    private Vector3 screenPoint;
    private Vector3 offset;

    void Start()
    {
    
    }
    
    void Update()
    {
       
    }

    void OnMouseDown()
    {
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    void OnMouseDrag()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        transform.position = currentPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Sprite gazo = Resources.Load<Sprite>("opbox");
        GameObject.Find("box").GetComponent<UnityEngine.SpriteRenderer>().sprite = gazo;
        Invoke("setActive", 0.5f);
    }

    void setActive()
    {
        clear.SetActive(true);
    }
}