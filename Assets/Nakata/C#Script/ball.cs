using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public int id;
    [SerializeField] GameObject explosionPrefab = default;
    public void Explosion()
    {
        //���j�G�t�F�N�g�𐶐����Ĕj��
        GameObject explosion =  Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explosion, 0.2f);
    }
}
