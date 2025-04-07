using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDatosJuego : MonoBehaviour
{
    public static ControladorDatosJuego instancia; // Instancia única

    public GameObject jugador;
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
        }

        // Nuevo: Reiniciar vida y puntos si se presiona "B" o "R"
        if (Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.R))
        {
            ReiniciarDatos();
        }
    }

    private void ReiniciarDatos()
    {
        // Valores iniciales
        float puntosIniciales = 0;

        // Restaurar vida del jugador


        // Restaurar puntos
        if (Puntaje.instancia != null)
        {
            Puntaje.instancia.Puntos = puntosIniciales;
            Puntaje.instancia.ActualizarTextoPuntaje();
        }

        // Guardar valores reiniciados en PlayerPrefs
        PlayerPrefs.SetFloat("Puntos", puntosIniciales);
        PlayerPrefs.Save();

        // Mensaje en consola
        Debug.Log("🔄 Datos reiniciados: Puntos = " + puntosIniciales);
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

        string escenaGuardada = PlayerPrefs.GetString("EscenaActual", "");
        string escenaActual = SceneManager.GetActiveScene().name;

        Debug.Log("📌 Última escena guardada: " + escenaGuardada);
        Debug.Log("📌 Escena actual: " + escenaActual);

        // Restaurar puntos
        float puntosGuardados = PlayerPrefs.GetFloat("Puntos", 0);
        if (Puntaje.instancia != null)
        {
            Puntaje.instancia.Puntos = puntosGuardados;
            Puntaje.instancia.ActualizarTextoPuntaje();
        }
        Debug.Log("⭐ Puntos restaurados: " + puntosGuardados);

        // Restaurar posición solo si la escena es la misma
        if (escenaGuardada == escenaActual)
        {
            float x = PlayerPrefs.GetFloat("PosX", jugador.transform.position.x);
            float y = PlayerPrefs.GetFloat("PosY", jugador.transform.position.y);
            float z = PlayerPrefs.GetFloat("PosZ", jugador.transform.position.z);

            jugador.transform.position = new Vector3(x, y, z);
            Debug.Log("📌 Posición restaurada: " + jugador.transform.position);
        }
        else
        {
            Debug.Log("📌 Nueva escena detectada, ignorando coordenadas previas.");

            // Actualizar escena actual para futuros guardados
            PlayerPrefs.SetString("EscenaActual", escenaActual);
            PlayerPrefs.Save();
        }
    }

    public void GuardarDatos()
    {
        ReasignarJugador(); // Asegurar que el jugador no sea nulo antes de acceder a él

        PlayerPrefs.SetFloat("PosX", jugador.transform.position.x);
        PlayerPrefs.SetFloat("PosY", jugador.transform.position.y);
        PlayerPrefs.SetFloat("PosZ", jugador.transform.position.z);
        PlayerPrefs.SetFloat("Puntos", Puntaje.instancia != null ? Puntaje.instancia.Puntos : 0);
        PlayerPrefs.SetString("UltimaEscena", SceneManager.GetActiveScene().name);

        PlayerPrefs.Save(); // Guardar los datos

        Debug.Log("✅ Datos guardados en PlayerPrefs (sin vida).");
    }
}
