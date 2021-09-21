using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatingLines : MonoBehaviour
{
	public GameObject singularTextLine;
	public Transform transformFrom;
	public int lineCount;
    public float vSpacing;
    public float hSpacing;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < lineCount; i++){
        	bool reverse = i % 2 == 0;
        	GameObject Cool = (GameObject) Instantiate(singularTextLine, transformFrom.transform.position, transformFrom.transform.rotation, transformFrom);
        	TextLineStuff Cooler = Cool.GetComponent<TextLineStuff>();
        	Cooler.enabled = true;
        	Cooler.reverse = reverse;
        	Cool.transform.localPosition = new Vector3(reverse==true?( hSpacing ):( -hSpacing ),(i*vSpacing),0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
