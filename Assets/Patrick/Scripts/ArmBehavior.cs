using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBehavior : MonoBehaviour
{
    [SerializeField] private float _lifeTimer = 1f;
    private float _speed = 0.9f;
    private Vector3 _armStockPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //_armStockPosition = new Vector3(0f, transform.position.y, 0f);
        //transform.position = Vector3.Lerp(transform.position, _armStockPosition, _speed * Time.deltaTime);

        _lifeTimer -= Time.deltaTime;
        if (_lifeTimer < 0 )
        {
            Destroy(gameObject);
        }
    }
}
