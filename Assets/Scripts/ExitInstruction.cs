using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitInstruction : MonoBehaviour
{
    public void CambiarEscena()
    {
        SceneManager.LoadScene("Selection");
        GameManager.Instance.vidaMaxima = 100f;
    }
}
