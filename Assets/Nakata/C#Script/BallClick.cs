using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallClick : MonoBehaviour
{
    [SerializeField] GameObject ballCorrect;
    private GameObject StatusDirector;

    private void Start()
    {
        StatusDirector = GameObject.Find("StatusDirector");
    }

    public void OnClick()
    {
        ballCorrect.SetActive(true);
        StatusDirector.GetComponent<StatusDirector>().NumberClick();
    }
}
