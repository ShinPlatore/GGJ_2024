using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private GameObject _canvas = null;
    public bool _hasSpaced = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _hasSpaced == false)
        {
            _hasSpaced = true;
            gameObject.transform.Translate(25, _speed * Time.deltaTime, 0);
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(0.05f);
        Debug.Log("Start");
        _hasSpaced = false;
        gameObject.transform.Translate(-25,0,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Eye")
        {
            Debug.Log("Victory Eye!");
            _canvas.SetActive(true);
            Time.timeScale = 0;
        }
        else{
            StartCoroutine(Restart());
        }
    }
}