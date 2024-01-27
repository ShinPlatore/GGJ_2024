using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBehavior : MonoBehaviour
{
    [SerializeField] private float _lifeTimer = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _lifeTimer -= Time.deltaTime;
        if (_lifeTimer < 0 )
        {
            Destroy(gameObject);
        }
    }
}
