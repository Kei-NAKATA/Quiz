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
    [SerializeField] GameObject clear;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        AddScore(0);
        StartCoroutine(ballGenerator.Spawns(ParamsSO.Entity.initBallCount));
    }

    void AddScore(int point)
    {
        score += point;
        scoreText.text = score.ToString();
        if(score >= ParamsSO.Entity.clearScore)
        {
            clear.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //右クリック押し込み
            OnDragBegin();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //右クリックを離す
            OnDragEnd();
        }
        else if (isDragging)
        {
            OnDragging();
        }
    }

    void OnDragBegin()
    {
        //マウスによるオブジェクトの判定
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
            //同じ種類
            if(ball.id == currentDraggingBall.id)
            {
                //距離が近い
                float distance = Vector2.Distance(ball.transform.position, currentDraggingBall.transform.position);
                if (distance < ParamsSO.Entity.ballDistance)
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
                removeBalls[i].Explosion();
                Destroy(removeBalls[i].gameObject);
            }
            StartCoroutine(ballGenerator.Spawns(removeCount));
            AddScore(removeCount * ParamsSO.Entity.scorePoint);
            Debug.Log($"スコア:{removeCount * 100}");
        }
        for (int i = 0; i < removeCount; i++)
        {
            removeBalls[i].GetComponent<SpriteRenderer>().color = Color.white;
            removeBalls[i].transform.localScale = Vector2.one;
        }
        removeBalls.Clear();
        isDragging = false;
    }

    void AddRemoveBall(ball ball)
    {
        currentDraggingBall = ball;
        if (removeBalls.Contains(ball) == false)
        {
            ball.transform.localScale = Vector2.one * 1.3f;
            ball.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            removeBalls.Add(ball);
        }
    }
}
