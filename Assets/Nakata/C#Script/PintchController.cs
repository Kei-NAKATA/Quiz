using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PintchController : MonoBehaviour
{
    [SerializeField] GameObject clear;

    public Vector2 startPos;
    public Vector2 mouseStartPos;
    float dist0 = 0f;
    float dist1 = 0f;
    float scale = 0f;
    float oldDist = 0f;//前回の2点間の距離
    float minRate = 0.1f;
    float maxRate = 16.0f;
    Vector3 v = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount >= 2)
        {
            Touch t1 = Input.GetTouch(0);
            Touch t2 = Input.GetTouch(1);
            if (t2.phase == TouchPhase.Began)
            {
                dist0 = Vector2.Distance(t1.position, t2.position);
                oldDist = dist0;
            }
            else if (t1.phase == TouchPhase.Moved && t2.phase == TouchPhase.Moved)
            {
                dist1 = Vector2.Distance(t1.position, t2.position);
                if (dist0 < 0.001f || dist1 < 0.001f)
                {
                    return;
                }
                else
                {
                    v = transform.localScale;
                    scale = v.x;
                    scale += (dist1 - oldDist) / 200f;
                    if (scale > maxRate) 
                    {
                        Sprite gazo = Resources.Load<Sprite>("niwatori");
                        GameObject.Find("Canvas/hiyoko").GetComponent<UnityEngine.UI.Image>().sprite = gazo;
                        Invoke("setActive", 0.5f);
                    }
                    if (scale < minRate) scale = minRate;
                    oldDist = dist1;
                }
                transform.localScale = new Vector3(scale, scale, scale);
                Debug.Log(scale);
            }
        }
    }

    void setActive()
    {
        clear.SetActive(true);
    }
}
