using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : Singleton<Manager>
{
    [SerializeField] private Vector3 _playerPosition = new Vector3 (-118.26f, -2.2216f, 0f);
    [SerializeField] private Vector3 _CameraPosition = new Vector3 (-118.259972f, 0.805171013f, -7.77931023f);

    private float _background = 0.3f;
    private float _scrolling = 4f;

    public Vector3 PlayerPosition
    {
        get { return _playerPosition; }

        set { _playerPosition = value; }
    }

    public Vector3 CameraPosition
    {
        get { return _CameraPosition; }
        set { _CameraPosition = value; }

    }

    public float Background
    {
        get { return _background; }
        set { _background = value; }
    }

    public float Scrolling
    {
        get { return _scrolling; }
        set { _scrolling = value; }

    }
}
