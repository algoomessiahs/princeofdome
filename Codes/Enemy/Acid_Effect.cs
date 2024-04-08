using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid_Effect : MonoBehaviour
{
    public float metrePerSecond = 3f;
    public float destroyAfter = 5f;

    private void Start()
    {
        Destroy(this.gameObject, destroyAfter);
    }
    private void Update()
    {
        transform.Translate(Vector3.right * metrePerSecond * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IDamageable hit = other.GetComponent<IDamageable>();

            if (hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }
    }
}
