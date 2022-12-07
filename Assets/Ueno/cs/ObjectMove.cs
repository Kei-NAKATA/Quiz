using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectMove : MonoBehaviour
{

    void Start()
    {
        //Rigidbody���擾
        var rb = GetComponent<Rigidbody2D>();

        //FreezePositionX���I���ɂ���
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
    }

    void OnMouseDrag()
    {
        //�}�E�X�̍��W���擾���ăX�N���[�����W���X�V
        Vector3 thisPosition = Input.mousePosition;
        //�X�N���[�����W�����[���h���W
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(thisPosition);
        worldPosition.z = 0f;
        worldPosition.x = -1.66f;
        worldPosition.y += 2.6f;

        if (worldPosition.y >= 3.54f)
        {
            worldPosition.y = 3.54f;
        }

        if (worldPosition.y <= 2.58f)
        {
            worldPosition.y = 2.58f;
            SceneManager.LoadScene("tutoriall13");
        }
        this.transform.position = worldPosition;
    }
}