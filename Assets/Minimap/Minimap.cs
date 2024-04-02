using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{

    public Transform player;
    public GameObject fullMapPanel; // Refer�ncia ao painel que cont�m a imagem do mapa completo
    public Camera fullMapCamera; // Refer�ncia � c�mera do mapa completo

    void Start()
    {
        // Assegura que o painel do mapa completo e a c�mera estejam desativados no in�cio
        fullMapPanel.SetActive(false);
        fullMapCamera.gameObject.SetActive(false); // Desativa a c�mera do mapa completo
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
            // Ativa ou desativa o painel do mapa completo e a c�mera
            bool isActive = !fullMapPanel.activeSelf;
            fullMapPanel.SetActive(isActive);
            fullMapCamera.gameObject.SetActive(isActive); // Ativa ou desativa a c�mera junto com o painel
        }
    }

}