using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ControladorDatosJuego : MonoBehaviour
{

    public GameObject jugador;

    public string archivoGuardado;

    public DatosJuegos datosJuego = new DatosJuegos();

    //int vidas;

    private void Awake()
    {
        archivoGuardado = Application.dataPath + "/datosJuego.json";

        jugador = GameObject.FindGameObjectWithTag("Player");

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

    private void CargarDatos()
    {
        if (File.Exists(archivoGuardado))
        {
            string contenido = File.ReadAllText(archivoGuardado);
            datosJuego = JsonUtility.FromJson<DatosJuegos>(contenido);

            Debug.Log("Posicion Jugador : " + datosJuego.posicion);

            Debug.Log("vida Jugador : " + datosJuego.VidaGuardada);

            jugador.transform.position = datosJuego.posicion;

           jugador.GetComponent<Movimiento_Buzo>().Vida = datosJuego.VidaGuardada;

           //jugador.GetComponent<Puntaje>().Puntos = datosJuego.PuntosGuardados;
        }
        else
        {
            Debug.Log("El archivo no existe");
        }
    }

    private void GuardarDatos()
    {
        DatosJuegos nuevosDatos = new DatosJuegos()
        {
            posicion = jugador.transform.position,

            //VidaGuardada = jugador.GetComponent<Movimiento_Buzo>().Vida,

            VidaGuardada = jugador.GetComponent<Movimiento_Buzo>().Vida,

           //PuntosGuardados = jugador.GetComponent<Puntaje>().Puntos
        };
       
        string cadenaJSON = JsonUtility.ToJson(nuevosDatos);
        File.WriteAllText(archivoGuardado, cadenaJSON);
        Debug.Log("Archivo guardado");
        

    }
}
