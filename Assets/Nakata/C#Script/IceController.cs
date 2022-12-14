using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IceController : MonoBehaviour
{
    // 追加
    private Vector3 screenPoint;
    private Vector3 offset;
    float hp = 5.0f;
    float delta = 0;

    SpriteRenderer MainSpriteReder;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(this.delta > 2.0f)
        {
            Sprite gazo = Resources.Load<Sprite>("meltingice");
            GameObject.Find("ice").GetComponent<UnityEngine.SpriteRenderer>().sprite = gazo;
        }
        if (this.delta > this.hp)
        {
            SceneManager.LoadScene("WaterScene");
        }
    }

    // 追加
    void OnMouseDown()
    {
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    // 追加
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
