using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonNavigationHandler : MonoBehaviour
{
   public void goTo(int index){
        SceneManager.LoadScene(index);
    }
}
