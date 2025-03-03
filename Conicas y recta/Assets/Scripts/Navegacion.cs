using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Navegacion : MonoBehaviour
{
    public void ejecutarMain(){
        SceneManager.LoadScene("Main");
        //cuando se llama a esta función, se cambiará la escena activa a la escena "Main".
    }

    public void regresarInicio(){
        SceneManager.LoadScene("Inicio");
        //cuando se llama a esta función, se cambiará la escena activa a la escena "Inicio".
    }

    public void ejecutarInfo(){
        SceneManager.LoadScene("Informacion");
        //cuando se llama a esta función, se cambiará la escena activa a la escena "Informacion".
    }
}
