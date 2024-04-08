using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Fire : MonoBehaviour
{
    public GameObject acid_effect_prefab;
    public void Fire()
    {
        Instantiate(acid_effect_prefab, transform.position, transform.rotation);
    }

}
