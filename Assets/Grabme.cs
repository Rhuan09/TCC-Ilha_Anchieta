using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Grabme : MonoBehaviour
{
    public TextMeshPro messageText;  // Arraste o componente de UI Text aqui no inspetor
    private bool isPlayerNear = false;

    void Start()
    {
        // Certifique-se de que a mensagem de texto est� desativada no in�cio
        messageText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Verifica se o jogador est� perto e pressionou 'E'
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            Console.Write("ta perto mano");
            messageText.gameObject.SetActive(true);
            messageText.text = "Voc� interagiu com o objeto!";
        }
    }

    // Detecta se o player entrou no trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    // Detecta se o player saiu do trigger
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            messageText.gameObject.SetActive(false);  // Esconde a mensagem quando o player sai
        }
    }
}

