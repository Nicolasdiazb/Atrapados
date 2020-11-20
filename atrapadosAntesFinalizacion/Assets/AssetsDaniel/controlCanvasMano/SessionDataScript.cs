using UnityEngine;

/// <summary>Manages data for persistance between play sessions.</summary>
public class SessionDataScript : MonoBehaviour
{
    public int pId;
    public string pNombre, pApellido, pUsuario, pEmail;
    //public static GameObject pCanvasVida;
    public static int Id;
    public static string nombre, apellido, usuario, email;
   // public static GameObject canvasVida; 

    public static int ID
    {
        get
        {
            return Id;
        }
        set
        {
            Id = value;
        }
    }

    public static string Nombre {
        get
        {
            return nombre;
        }
        set
        {
            nombre = value;
        }
    }

    public static string Apellido {
        get
        {
            return apellido;
        }
        set
        {
            apellido = value;
        }
    }

    public static string Usuario
    {
        get
        {
            return usuario;
        }
        set
        {
            usuario = value;
        }
    }

    public static string Email
    {
        get
        {
            return email;
        }
        set
        {
            email = value;
        }
    }

    //public static GameObject canvasVida
    //{
    //    get
    //    {
    //        return canvasVida;
    //    }
    //    set
    //    {
    //        canvasVida = value;
    //    }
    //}

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Update()
    {
        pId = Id;
        pNombre = nombre;
        pApellido = apellido;
        pUsuario = usuario;
        pEmail = email;
       // pCanvasVida = canvasVida;
    }

}