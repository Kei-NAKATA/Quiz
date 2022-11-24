using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallClick : MonoBehaviour
{
    [SerializeField] GameObject ballCorrect;

    public void OnClick()
    {
        ballCorrect.SetActive(true);
    }
}
