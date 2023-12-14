using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RiddleM : MonoBehaviour
{
    
    public void ChooseA()
    {
        SceneManager.LoadScene(1);
    }
    public void ChooseB()
    {
        PlayerDet.failed = true;
        SceneManager.LoadScene(1);
    }

}
