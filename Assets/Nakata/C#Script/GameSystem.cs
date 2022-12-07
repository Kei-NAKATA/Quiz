using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    [SerializeField] BallGenerator ballGenerator = default;
    bool isDragging;
    [SerializeField] List<ball> removeBalls = new List<ball>();
    ball currentDraggingBall;
    int score;
    [SerializeField] Text scoreText = default;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        AddScore(0);
        StartCoroutine(ballGenerator.Spawns(30));
    }

    void AddScore(int point)
    {
        score += point;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //�E�N���b�N��������
            OnDragBegin();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //�E�N���b�N�𗣂�
            OnDragEnd();
        }
        else if (isDragging)
        {
            OnDragging();
        }
    }

    void OnDragBegin()
    {
        //�}�E�X�ɂ��I�u�W�F�N�g�̔���
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit && hit.collider.GetComponent<ball>())
        {
            ball ball = hit.collider.GetComponent<ball>();
            AddRemoveBall(ball);
            isDragging = true;
        }
    }

    void OnDragging()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit && hit.collider.GetComponent<ball>())
        {
            ball ball = hit.collider.GetComponent<ball>();
            //�������
            if(ball.id == currentDraggingBall.id)
            {
                //�������߂�
                float distance = Vector2.Distance(ball.transform.position, currentDraggingBall.transform.position);
                if (distance < 1.0)
                {
                    AddRemoveBall(ball);
                }
            }
            
        }

    }

    void OnDragEnd()
    {
        int removeCount = removeBalls.Count;
        if (removeCount >= 3)
        {
            for (int i = 0; i < removeCount; i++)
            {
                Destroy(removeBalls[i].gameObject);
            }
            StartCoroutine(ballGenerator.Spawns(removeCount));
            AddScore(removeCount * 100);
            Debug.Log($"�X�R�A:{removeCount * 100}");
        }
        removeBalls.Clear();
        isDragging = false;
    }

    void AddRemoveBall(ball ball)
    {
        currentDraggingBall = ball;
        if (removeBalls.Contains(ball) == false)
        {
            removeBalls.Add(ball);
        }
    }
}
