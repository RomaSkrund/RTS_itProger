using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [NonSerialized]
    public Vector3 position;
    public float speed = 30f;
    int damage = 20;

    private void Update()
    {
        float spep = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards
            (transform.position, position, spep);

        if (transform.position == position)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            CarAttack attack = other.GetComponent<CarAttack>();
            attack._health -= damage;

            Transform healthBar =  other.transform.GetChild(0).transform;
            healthBar.localScale = new Vector3(
                healthBar.localScale.x - 0.3f,
                healthBar.localScale.y,
                healthBar.localScale.z);

            if (attack._health <= 0) 
            {
                Destroy(other.gameObject);
            }
        }
    }

}
