using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineStateDrivenCamera _cinemachineStateDrivenCamera;
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;


    private void OnEnable()
    {
        EventManager.CameraTarget += SetCameraTarget;
    }

    private void OnDisable()
    {
        EventManager.CameraTarget -= SetCameraTarget;
    }

    public void SetCameraTarget(Transform player)
    {
        _cinemachineStateDrivenCamera.m_Follow = player;
        _cinemachineStateDrivenCamera.m_LookAt = player;
        _cinemachineVirtualCamera.m_Follow = player;
        _cinemachineVirtualCamera.m_LookAt = player;
    }
}
