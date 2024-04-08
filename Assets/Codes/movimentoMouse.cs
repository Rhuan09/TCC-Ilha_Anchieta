using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoMouse : MonoBehaviour
{
    public float mouseSensitivity = 50f; // Sensibilidade do mouse para a rotação da câmera
    public float movementSpeed = 60f; // Velocidade de movimento da personagem

    private float rotationX = 0f;
    private float rotationY = 0f;

    private GameObject playerCapsule; // Referência ao objeto da cápsula do jogador

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela
        Cursor.visible = false; // Torna o cursor invisível

        playerCapsule = GameObject.Find("PlayerCapsule"); // Encontre o objeto da cápsula do jogador pelo nome
        playerCapsule.SetActive(false); // Desativa o objeto da cápsula
    }

    void Update()
    {
        // Obter os movimentos do mouse para a rotação da câmera
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Calcular a rotação horizontal e vertical da câmera
        rotationX += mouseX * mouseSensitivity;
        rotationY -= mouseY * mouseSensitivity; // Subtrai para inverter a rotação vertical

        // Limitar a rotação vertical entre -90 e 90 graus
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        // Aplicar as rotações à câmera
        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0f);

        // Obter as entradas de movimento do teclado
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        // Calcular o vetor de movimento
        Vector3 movement = (transform.right * horizontalMovement + transform.forward * verticalMovement) * movementSpeed * Time.deltaTime;

        // Mover o objeto do jogador
        transform.position += movement;

        // Ocultar ou exibir a cápsula do jogador
        if (Input.GetKeyDown(KeyCode.H))
        {
            playerCapsule.SetActive(!playerCapsule.activeSelf);
        }
    }
}