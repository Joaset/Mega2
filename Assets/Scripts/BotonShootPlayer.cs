using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonShootPlayer : MonoBehaviour
{
    private ShootPlayer shooter;
    [SerializeField] private ShootPlayerFinal shooterFinal;

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            if (shooterFinal == null)
            {
                shooterFinal = FindAnyObjectByType<ShootPlayerFinal>();
            }
        }
        else
        {
            // Si no tiene referencia al disparo, busca al jugador
            if (shooter == null)
            {
                shooter = FindAnyObjectByType<ShootPlayer>();
            }
        }
    }

    public void DispararBoton()
    {
         if (shooter != null)
             shooter.Shoot();
    }

    public void DispararBotonFinal()
    {
        if (shooterFinal != null)
            shooterFinal.Shoot();
    }
}
