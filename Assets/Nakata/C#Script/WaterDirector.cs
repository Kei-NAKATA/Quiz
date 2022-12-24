using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDirector : MonoBehaviour
{
    [SerializeField] GameObject clear;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("setActive", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setActive()
    {
        clear.SetActive(true);
    }
}
