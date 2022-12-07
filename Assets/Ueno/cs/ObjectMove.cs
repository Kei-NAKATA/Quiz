using System.Collections;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    void Start()
    {
        //Rigidbodyを取得
        var rb = GetComponent<Rigidbody>();

        //FreezePositionXをオンにする
        rb.constraints = RigidbodyConstraints.FreezePositionX;
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

        if (worldPosition.y <= 2.58f)
        {
            worldPosition.y = 2.58f;
        }

        this.transform.position = worldPosition;
    }
}