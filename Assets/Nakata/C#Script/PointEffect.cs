using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointEffect : MonoBehaviour
{
    [SerializeField] Text text = default;
    public void Show(int score)
    {
        text.text = score.ToString();
        StartCoroutine(MoveUp());
    }

    IEnumerator MoveUp()
    {
        for (int i=0; i<25; i++)
        {
            yield return new WaitForSeconds(0.01f);

            transform.Translate(0, 0.05f, 0);
        }
        Destroy(gameObject, 0.2f);
    }
}
