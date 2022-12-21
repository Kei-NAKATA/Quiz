using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch_effect: MonoBehaviour
{
    public GameObject prefab;
    public float deleteTime = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //�}�E�X�J�[�\���̈ʒu���擾�B
            var mousePosition = Input.mousePosition;
            mousePosition.z = 3f;
            GameObject clone = Instantiate(prefab, Camera.main.ScreenToWorldPoint(mousePosition),
                Quaternion.identity);
            Destroy(clone, deleteTime);
        }
    }

}