using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManger : MonoBehaviour
{
    [Header("UI×é¼þ")]
    public GameObject GameOverPanel;
    public GameObject GameClearPanel;
    public Button REstart;
    public Button Continue;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        REstart.onClick.AddListener(OnRestartClick);
        Continue.onClick.AddListener(OnRestartClick);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1200 )
        {
            GameClearPanel.SetActive(true);
        }
        
    }
    public void ShouGameOverPanel()
    {
        GameOverPanel.SetActive(true);
    }
    public void OnRestartClick()
    {
        SceneLoader.Instance.LoadMainScene();
    }
}
