using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    [SerializeField] private float _backgroundSpeed = 0.3f;
    [SerializeField] private Renderer _backgroundRenderer = null;

    public float BackgroundSpeed
    {
        get { return _backgroundSpeed; }
        set { _backgroundSpeed = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        _backgroundSpeed = Manager.Instance.Background;
    }

    // Update is called once per frame
    void Update()
    {
        _backgroundSpeed += Time.fixedDeltaTime / 20000;
        _backgroundRenderer.material.mainTextureOffset += new Vector2(_backgroundSpeed * Time.deltaTime, 0f);
    }
}
