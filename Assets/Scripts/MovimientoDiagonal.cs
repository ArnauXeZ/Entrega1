using UnityEngine;

public class MovimientoDiagonal : MonoBehaviour
{
    public float tiempoEntreMovimientos = 1f; // Ajusta el tiempo entre movimientos 

    private float tiempoPasado;
    private Vector2 posicionActual;

    void Start()
    {
        posicionActual = transform.position;
    }

    void Update()
    {
        tiempoPasado += Time.deltaTime;

        // Verificar la entrada de teclado para movimientos diagonales
        if (tiempoPasado >= tiempoEntreMovimientos)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                MoverDiagonal(-1, 1);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                MoverDiagonal(1, 1);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                MoverDiagonal(-1, -1);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                MoverDiagonal(1, -1);
            }

            tiempoPasado = 0f;
        }
    }

    void MoverDiagonal(int direccionX, int direccionY)
    {
        Vector2 nuevaPosicion = new Vector2(posicionActual.x + direccionX, posicionActual.y + direccionY);

        // Verificar si la nueva posición está dentro de los límites y no retrocede
        if (EsPosicionValida(nuevaPosicion))
        {
            transform.position = nuevaPosicion;
            posicionActual = nuevaPosicion;
        }
    }

    bool EsPosicionValida(Vector2 posicion)
    {
        // Verifica si la nueva posición no es un movimiento hacia atrás
        return Mathf.Abs(posicion.x - posicionActual.x) <= 1 && Mathf.Abs(posicion.y - posicionActual.y) <= 1;
    }
}

