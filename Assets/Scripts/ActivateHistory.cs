using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using StarterAssets;
using UnityEngine.UI;

public class ActivateHistory : MonoBehaviour
{
    [SerializeField] TMP_Text _TextObject;
    [SerializeField] string _Text;
    [SerializeField] GameObject _helper, _uiText, _uiImage, _CanvasObject;
    [SerializeField] GameObject _papiro;
    [SerializeField] Sprite _imagemLocal;
    Transform pos;
    [SerializeField] bool _PodeAnimar;
    [SerializeField] float _velocidade, _alturaMin, _alturaMax;
    
    void Start()
    {
        _TextObject.text = "";

        if (_imagemLocal != null)
        {
            _uiImage.GetComponent<Image>().sprite = _imagemLocal;
        }
        _CanvasObject.SetActive(false);
        pos = _papiro.transform;
        StartCoroutine(PapiroMove());
    }

    private void ShowText()
    {
        _CanvasObject.SetActive(true);
        _helper.SetActive(false);
        _uiText.SetActive(true);
        _uiImage.SetActive(true);
        _TextObject.text = _Text;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _CanvasObject.SetActive(true);
            _helper.SetActive(true);
            _uiText.SetActive(false);
            _uiImage.SetActive(false);
            FirstPersonController.OnClick += ShowText;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _helper.SetActive(false);
        _uiText.SetActive(false);
        _uiImage.SetActive(false);
        _CanvasObject?.SetActive(false);
        FirstPersonController.OnClick -= ShowText;
    }

    IEnumerator PapiroMove()
    {
        while (_PodeAnimar)
        {
            while (_papiro.transform.localPosition.y >= _alturaMin)
            {
                _papiro.transform.position -= new Vector3(0, Time.deltaTime * _velocidade, 0);

                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(.1f);

            while (_papiro.transform.localPosition.y <= _alturaMax)
            {
                _papiro.transform.position += new Vector3(0, Time.deltaTime * _velocidade, 0);

                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(.1f);
        }
    }
}
