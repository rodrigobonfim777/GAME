using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // 1. O alvo que a câmera deve seguir (seu pivô)
    public Transform target;

    // 2. Tempo para alcançar o player
    public float smoothTime = 0.3f;

    // 3. Velocidade atual usada pelo SmoothDamp
    private Vector3 currentVelocity = Vector3.zero;

    private void LateUpdate()
    {
        // Previne erros caso você esqueça de referenciar o pivô no Inspector
        if (target == null) return;

        // Cria a posição alvo mantendo o Z original da câmera (para não bugar o 2D)
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

        // Suaviza a posição atual até a posição alvo
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
    }
}