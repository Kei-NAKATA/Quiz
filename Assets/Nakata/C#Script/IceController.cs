using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IceController : MonoBehaviour
{
    // �ǉ�
    private Vector3 screenPoint;
    private Vector3 offset;
    float hp = 10.0f;
    float delta = 0;

    SpriteRenderer MainSpriteReder;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.delta > this.hp)
        {
            SceneManager.LoadScene("WaterScene");
        }
    }

    // �ǉ�
    void OnMouseDown()
    {
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    // �ǉ�
    void OnMouseDrag()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        transform.position = currentPosition;
    }

    void OnTriggerStay2D(Collider2D other)
    {

        this.delta += Time.deltaTime;
        Debug.Log(this.delta);
    }
}
