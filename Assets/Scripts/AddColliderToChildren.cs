using UnityEngine;

public class AddColliderToChildren : MonoBehaviour
{
    void Start()
    {
        // Adiciona o Mesh Collider a todos os filhos do GameObject atual
        foreach (Transform child in transform)
        {
            // Verifica se o GameObject filho tem um MeshRenderer (opcional)
            MeshRenderer meshRenderer = child.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                // Adiciona o Mesh Collider se n�o existir
                if (child.GetComponent<MeshCollider>() == null)
                {
                    child.gameObject.AddComponent<MeshCollider>();
                    Debug.Log($"Mesh Collider adicionado a {child.name}");
                }
            }
        }

        Debug.Log("Processo conclu�do!");
    }
}
