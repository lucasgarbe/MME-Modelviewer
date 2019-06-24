using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
	public Canvas menu;

    // Start is called before the first frame update
    void Start()
    {
        menu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape")){
			if(menu.enabled == false){
				menu.enabled = true;
			}else{
				menu.enabled = false;
			}
		}
    }
}
