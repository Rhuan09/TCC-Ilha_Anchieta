using UnityEngine;
using UnityEngine.XR;

public class VRModeSwitcher : MonoBehaviour
{
   [SerializeField]public Camera vrCamera;     // Defina sua câmera para VR
   [SerializeField]public Camera standardCamera; // Defina sua câmera padrão (não VR)

    void Start()
    {
        SetCameraMode();
    }

    void SetCameraMode()
    {
        if (XRSettings.isDeviceActive)
        {
            // Ativa a câmera VR e desativa a câmera padrão
            vrCamera.enabled = true;
            standardCamera.enabled = false;
            XRSettings.enabled = true;
        }
        else
        {
            // Ativa a câmera padrão e desativa a câmera VR
            vrCamera.enabled = false;
            standardCamera.enabled = true;
            XRSettings.enabled = false;
        }
    }
}
