using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class ControladorDatosJuego : MonoBehaviour
{

    public static ControladorDatosJuego instancia; // Instancia única

    public GameObject jugador;

    public string archivoGuardado;

    public DatosJuegos datosJuego = new DatosJuegos();

    //int vidas;

    public Puntaje puntaje;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        puntaje = FindObjectOfType<Puntaje>(); // Busca el script en la escena

        if (jugador == null)
        {
            Debug.LogError("No se encontró un objeto con la etiqueta 'Player'.");
        }

        if (puntaje == null)
        {
            Debug.LogError("No se encontró el script 'Puntaje' en la escena.");
        }
    }


    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // Evita que se destruya al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, elimina la nueva
        }

        archivoGuardado = Application.dataPath + "/datosJuego.json";

        jugador = GameObject.FindGameObjectWithTag("Player");

        puntaje = FindObjectOfType<Puntaje>();
        if (puntaje == null)
        {
            Debug.LogError("No se encontró el objeto Puntaje en la escena.");
        }

        CargarDatos();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CargarDatos();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            GuardarDatos();
            //vidas = jugador.GetComponent<Movimiento_Buzo>().Vida;
            //Debug.Log(vidas);

        }
    }

    private void ReasignarJugador()
    {
        if (jugador == null)
        {
            jugador = GameObject.FindGameObjectWithTag("Player");

            if (jugador == null)
            {
                Debug.LogError("No se encontró el objeto 'Player'. Verifica que el personaje tenga la etiqueta correcta.");
            }
        }
    }

    private void CargarDatos()
    {
        ReasignarJugador(); // Asegurar que el jugador no sea nulo antes de acceder a él

        if (File.Exists(archivoGuardado))
        {
            string contenido = File.ReadAllText(archivoGuardado);
            datosJuego = JsonUtility.FromJson<DatosJuegos>(contenido);

            Debug.Log("Cargando datos...");
            Debug.Log("Posición: " + datosJuego.posicion);
            Debug.Log("Vida: " + datosJuego.VidaGuardada);
            Debug.Log("Puntos Guardados: " + datosJuego.PuntosGuardados);

            // Si estamos en la misma escena que se guardó, restaurar la posición
            if (datosJuego.escenaActual == SceneManager.GetActiveScene().name)
            {
                jugador.transform.position = datosJuego.posicion;
            }
            else
            {
                Debug.Log("Nueva escena detectada, se mantiene la posición por defecto.");
            }

            // Restaurar la vida del jugador
            jugador.GetComponent<Movimiento_Buzo>().Vida = datosJuego.VidaGuardada;

            // Restaurar el puntaje sumándolo en lugar de sobrescribirlo
            if (Puntaje.instancia != null)
            {
                Puntaje.instancia.Puntos += datosJuego.PuntosGuardados; // Sumar en vez de sobrescribir
                Puntaje.instancia.ActualizarTextoPuntaje();
            }
            else
            {
                Debug.LogWarning("Puntaje es nulo, no se pueden cargar los puntos.");
            }
        }
        else
        {
            Debug.Log("No hay datos previos guardados.");
        }
    }



    public void GuardarDatos()
    {
        ReasignarJugador(); // Asegurar que el jugador no sea nulo antes de acceder a él

        DatosJuegos nuevosDatos = new DatosJuegos()
        {
            posicion = jugador.transform.position,
            VidaGuardada = jugador.GetComponent<Movimiento_Buzo>().Vida,
            PuntosGuardados = Puntaje.instancia != null ? Puntaje.instancia.Puntos : 0,
            escenaActual = SceneManager.GetActiveScene().name,

        };

        string cadenaJSON = JsonUtility.ToJson(nuevosDatos, true);
        File.WriteAllText(archivoGuardado, cadenaJSON);
        Debug.Log("Archivo guardado - Vida: " + nuevosDatos.VidaGuardada + " - Puntos: " + nuevosDatos.PuntosGuardados);
    }

}
