using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeManager : MonoBehaviour
{

    public static CameraShakeManager _instance;
    [SerializeField] private float _shakeForce = 1.0f;

    void Awake()
    {
        if(_instance == null )
        {
            _instance = this;
        }
    }

    public void CameraShake(CinemachineImpulseSource impulseSource)
    {
        impulseSource.GenerateImpulseWithForce(_shakeForce);
    }
}
