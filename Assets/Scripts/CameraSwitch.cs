using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject ThirdPersonCamera;
	public GameObject FirstPersonCamera;
    void Start()
    {
        FirstPersonCamera.SetActive(true);
		ThirdPersonCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.T))
		{
			FirstPersonCamera.SetActive(false);
			ThirdPersonCamera.SetActive(true);
		}
        if (Input.GetKeyDown (KeyCode.F))
		{
			FirstPersonCamera.SetActive(true);
			ThirdPersonCamera.SetActive(false);
		}
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			OnExitGame();
		}
    }
	public void OnExitGame()//退出游戏方法
    {
	#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//如果在unity编译器中
	#else
        Application.Quit();//否则在打包文件中
	#endif
    }
}
