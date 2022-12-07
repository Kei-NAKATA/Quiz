using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectMove : MonoBehaviour
{

    void Start()
    {
        //Rigidbodyを取得
        var rb = GetComponent<Rigidbody2D>();

        //FreezePositionXをオンにする
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    void OnMouseDrag()
    {
        //マウスの座標を取得してスクリーン座標を更新
        Vector3 thisPosition = Input.mousePosition;
        //スクリーン座標→ワールド座標
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(thisPosition);
        worldPosition.z = 0f;
        worldPosition.x = -1.66f;
        worldPosition.y += 2.6f;

        if (worldPosition.y >= 3.54f)
        {
            worldPosition.y = 3.54f;
        }

        if (worldPosition.y <= 2.58f)
        {
            worldPosition.y = 2.58f;
            SceneManager.LoadScene("tutoriall13");
        }
        this.transform.position = worldPosition;
    }
}