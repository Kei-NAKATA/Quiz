using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    //Ball��ݒ�
    [SerializeField] GameObject ballprefab = default;
    //�摜�̐ݒ�
    [SerializeField] Sprite[] ballSprites = default;

    // Start is called before the first frame update


    public IEnumerator Spawns(int count)
    {
        for(int i=0; i<count; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-0.05f, 0.05f), 8f);
            GameObject ball =  Instantiate(ballprefab, pos, Quaternion.identity);
            //�摜�̐ݒ�
            int ballID = Random.Range(0, ballSprites.Length);
            ball.GetComponent<SpriteRenderer>().sprite = ballSprites[ballID];
            ball.GetComponent<ball>().id = ballID;
            yield return new WaitForSeconds(0.04f);
        }
        
    }
}
