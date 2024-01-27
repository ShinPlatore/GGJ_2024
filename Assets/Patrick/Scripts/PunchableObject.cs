using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchableObject : MonoBehaviour
{
    [SerializeField] private bool _isAtHandReach = false;

    public bool isAtHandReach
    {
        get { return _isAtHandReach; }
        set { _isAtHandReach = value;}

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log(other.gameObject);
        }
    }


}
