using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fanhui_xuanguan : MonoBehaviour
{
    public void fanhuixuanguan()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("xuanguan");
    }
}
