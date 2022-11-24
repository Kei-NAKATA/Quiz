using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matigaeClick : MonoBehaviour
{
    [SerializeField] GameObject ballCorrect;
    public void OnClick()
    {
        ballCorrect.SetActive(true);
    }
}
