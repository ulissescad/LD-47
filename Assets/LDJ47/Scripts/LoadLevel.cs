using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    private string _levelName;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(LoadLevelByName);
    }

    // Update is called once per frame
    public void LoadLevelByName()
    {
        SceneManager.LoadScene(_levelName);
    }
}
