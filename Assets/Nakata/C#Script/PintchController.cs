using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PintchController : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 mouseStartPos;
    float dist0 = 0f;
    float dist1 = 0f;
    float scale = 0f;
    float oldDist = 0f;//�O���2�_�Ԃ̋���
    float minRate = 0.7f;
    float maxRate = 3f;
    Vector3 v = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch t1 = Input.GetTouch(0);
            if (t1.phase == TouchPhase.Began)
            {
                //�ړ�������UI�I�u�W�F�N�g�̍ŏ��̈ʒu
                startPos = transform.position;
                //�h���b�O���J�n�����Ƃ��̃}�E�X�̈ʒu
                mouseStartPos = t1.position;
            }
            else if (t1.phase == TouchPhase.Moved)
            {
                //�h���b�O����UI�I�u�W�F�N�g�̈ʒu
                transform.position
                        = startPos + (t1.position - mouseStartPos);
            }
        }
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
                    if (scale > maxRate) { scale = maxRate; }
                    if (scale < minRate) { scale = minRate; }
                    oldDist = dist1;
                }
                transform.localScale = new Vector3(scale, scale, scale);
            }
        }
    }
}
