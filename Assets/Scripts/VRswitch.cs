using UnityEngine;
using UnityEngine.XR;

public class VRModeSwitcher : MonoBehaviour
{
   [SerializeField]public Camera vrCamera;     // Defina sua c�mera para VR
   [SerializeField]public Camera standardCamera; // Defina sua c�mera padr�o (n�o VR)

    void Start()
    {
        SetCameraMode();
    }

    void SetCameraMode()
    {
        if (XRSettings.isDeviceActive)
        {
            // Ativa a c�mera VR e desativa a c�mera padr�o
            vrCamera.enabled = true;
            standardCamera.enabled = false;
            XRSettings.enabled = true;
        }
        else
        {
            // Ativa a c�mera padr�o e desativa a c�mera VR
            vrCamera.enabled = false;
            standardCamera.enabled = true;
            XRSettings.enabled = false;
        }
    }
}
