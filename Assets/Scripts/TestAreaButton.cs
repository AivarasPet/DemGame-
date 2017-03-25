using UnityEngine;
using System.Collections;

public class TestAreaButton : MonoBehaviour
{

    public void NextLevelButton(string world2)
    {
        Application.LoadLevel(world2);
    }
}