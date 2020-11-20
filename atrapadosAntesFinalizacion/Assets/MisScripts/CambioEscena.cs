using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CambioEscena : MonoBehaviour
{
    // Start is called before the first frame update

    public void IrTutorial()
    {
        SceneManager.LoadScene(1);
    }
}
