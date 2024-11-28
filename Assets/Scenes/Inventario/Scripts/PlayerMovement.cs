using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento do jogador

    private Vector3 moveDirection;

    void Update()
    {
        // Captura a entrada do teclado (W, A, S, D ou setas)
        float moveX = Input.GetAxis("Horizontal"); // A/D ou Setas Esquerda/Direita
        float moveZ = Input.GetAxis("Vertical");   // W/S ou Setas Cima/Baixo

        // Define a direção do movimento
        moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        // Move o jogador
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
 