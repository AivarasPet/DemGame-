using UnityEngine;
using System.Collections;

public class TestArea : MonoBehaviour
{
    public void NextLevelButton(int lol)
    {
        Application.LoadLevel(lol);
    }

    public void NextLevelButton(string world2)
    {
        Application.LoadLevel(world2);
    }
}