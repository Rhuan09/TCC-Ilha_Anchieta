using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using StarterAssets;

public class ActivateHistory : MonoBehaviour
{
   [SerializeField]TMP_Text _TextObject;
   [SerializeField]string _Text;
   [SerializeField]GameObject _CanvasObject;

    // Start is called before the first frame update
    void Start()
    {
        _TextObject.text = "";
        _CanvasObject.SetActive(false);

    }

    private void ShowText()
    {
        _CanvasObject.SetActive(true);
        _TextObject.text = _Text;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("triggerei");
        if (other.gameObject.CompareTag("Player")){
            FirstPersonController.OnClick += ShowText;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _CanvasObject?.SetActive(false);
        FirstPersonController.OnClick -= ShowText;
    }

}
