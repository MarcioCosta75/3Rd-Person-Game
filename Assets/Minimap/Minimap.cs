using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{

    public Transform player;
    public GameObject fullMapPanel; // Referência ao painel que contém a imagem do mapa completo
    public Camera fullMapCamera; // Referência à câmera do mapa completo

    void Start()
    {
        // Assegura que o painel do mapa completo e a câmera estejam desativados no início
        fullMapPanel.SetActive(false);
        fullMapCamera.gameObject.SetActive(false); // Desativa a câmera do mapa completo
    }

    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);

        // Verifica se a tecla "M" foi pressionada
        if (Input.GetKeyDown(KeyCode.M))
        {
            // Ativa ou desativa o painel do mapa completo e a câmera
            bool isActive = !fullMapPanel.activeSelf;
            fullMapPanel.SetActive(isActive);
            fullMapCamera.gameObject.SetActive(isActive); // Ativa ou desativa a câmera junto com o painel
        }
    }

}