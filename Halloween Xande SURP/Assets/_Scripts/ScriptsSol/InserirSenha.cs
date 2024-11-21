using UnityEngine;
using TMPro;

public class InserirSenha : MonoBehaviour
{
    [SerializeField] private TMP_InputField passwordInput; // Campo de entrada do TextMeshPro
    [SerializeField] private string correctPassword = "7685"; // Senha correta
    [SerializeField] private GameObject object1; // Primeiro objeto a ser ativado
    [SerializeField] private GameObject object2; // Segundo objeto a ser ativado
    [SerializeField] private GameObject objectToDeactivate; // Objeto a ser desativado

    public void CheckPassword()
    {
        // Verifica se a palavra inserida é a correta
        if (passwordInput.text == correctPassword)
        {
            // Ativa os dois objetos
            object1.SetActive(true);
            object2.SetActive(false);

            // Desativa o objeto especificado
            objectToDeactivate.SetActive(false);

            // Altera o texto do campo para "Correto!"
            passwordInput.text = "Correto!";
            Debug.Log("Senha correta! Objetos ativados e um desativado.");
        }
        else
        {
            Debug.Log("Senha incorreta.");
        }
    }
}
