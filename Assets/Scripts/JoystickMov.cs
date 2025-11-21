using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JoystickMov : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;
    [SerializeField] Joystick joystick;
    private float limiteX;
    private float limiteY;
    private float mitadAncho;
    private float mitadAlto;
    private Animator animator;

    [SerializeField] private float hudAbajo;
    [SerializeField] private float hudArriba;

    void Start()
    {
        // Tamaño real del sprite
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        mitadAncho = sr.bounds.extents.x;
        mitadAlto = sr.bounds.extents.y;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ? Obtener movimiento del joystick
        float movX = joystick.Horizontal;  // entre -1 y 1
        float movY = joystick.Vertical;    // entre -1 y 1

        // ? Mover al jugador (una sola vez)
        Vector3 direccion = new Vector3(movX, movY, 0f).normalized;
        transform.position += direccion * velocidad * Time.deltaTime;

        // ? Animaciones
        animator.SetBool("Up", movY > 0.1f);
        animator.SetBool("Down", movY < -0.1f);

        // ? Calcular límites de la cámara
        Camera cam = Camera.main;
        limiteY = cam.orthographicSize;
        limiteX = limiteY * cam.aspect;

        // ? Limitar dentro de la pantalla
        float x = Mathf.Clamp(transform.position.x, -limiteX + mitadAncho, limiteX - mitadAncho);
        float y = Mathf.Clamp(transform.position.y, -limiteY + mitadAlto + hudAbajo, limiteY - mitadAlto - hudArriba);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
