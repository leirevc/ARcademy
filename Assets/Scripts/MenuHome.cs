using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHome : MonoBehaviour
{
 
    //accedemos a la camara para la funcion AR
    public void EscanearImagen()
    {
        //indicar el nombre de la scene a la que se accede
        SceneManager.LoadScene("ImageTracking");
    }
}
