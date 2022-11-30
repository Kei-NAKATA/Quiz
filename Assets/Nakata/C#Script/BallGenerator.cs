using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    //Ball‚ğİ’è
    [SerializeField] GameObject ballprefab = default;
    //‰æ‘œ‚Ìİ’è
    [SerializeField] Sprite[] ballSprites = default;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawns(20));
    }


    public IEnumerator Spawns(int count)
    {
        for(int i=0; i<count; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-0.2f, 0.2f), 8f);
            GameObject ball =  Instantiate(ballprefab, pos, Quaternion.identity);
            //‰æ‘œ‚Ìİ’è
            int ballID = Random.Range(0, ballSprites.Length);
            ball.GetComponent<SpriteRenderer>().sprite = ballSprites[ballID];
            yield return new WaitForSeconds(0.04f);
        }
        
    }
}
