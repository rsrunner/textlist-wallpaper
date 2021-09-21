using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextLineStuff : MonoBehaviour
{
	public TextListHandler quoteHandler;
	public GameObject textBase;
	public Transform transformFrom;
	public bool reverse = false;
	public float speed;
    public float fontSize;
    public bool highlightText;
    public string regexHighlight;
    public Color highlightColor;
    Regex compiledRegex;
	List<GameObject> lines = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        compiledRegex = new Regex(regexHighlight, RegexOptions.IgnoreCase);
    	quoteHandler = quoteHandler.GetComponent<TextListHandler>();
    	transformFrom = transformFrom.GetComponent<Transform>();
    	InvokeRepeating("UpdateQuote", 0.0f, .5f);
    }

    // Update is called once per frame
    void Update()
    {
    	Vector3 moveBy = new Vector3(speed * Time.deltaTime, 0, 0);
        try{
            foreach(GameObject line in lines){
            	if(((reverse == true) ? (line.transform.localPosition.x > 10) : (line.transform.localPosition.x < -10))){
    	    		GameObject kill = line;
    	    		Destroy(kill);
    	    		lines.RemoveAt(lines.IndexOf(kill));
                    continue;
    	    	}

            	if(reverse == true){
            		line.transform.localPosition += moveBy;
            	}
            	else{
            		line.transform.localPosition -= moveBy;
            	}
            }
        }
        catch(InvalidOperationException shut_up){
            //make .net shut up
        }
    }

    void UpdateQuote(){
    	if(lines.Count > 10){
    		return;
    	}
    	List<string> quotes = quoteHandler.GetQuotes();
    	string quote = quotes[(int)UnityEngine.Random.Range(0, quotes.Count-1)];
    	//textBase.text = ;
    	GameObject newline = CreateNewText();
    	TextMeshPro newtext = newline.GetComponent<TextMeshPro>();
        newtext.fontSize = fontSize;
    	if(reverse == true){
    		newtext.alignment = TextAlignmentOptions.Right;
    	}
    	newtext.text = quote;
        if(highlightText == true){
            newtext.text = compiledRegex.Replace(newtext.text, "<#"+ColorUtility.ToHtmlStringRGBA(highlightColor)+">$1</color>");
        }
    	if(lines.Count >= 1){
    		GameObject oldline = lines[lines.Count - 1];
			TextMeshPro oldtext = oldline.GetComponent<TextMeshPro>();
			if(lines.Count <= 100){
				if(reverse == true){
					newline.transform.localPosition = new Vector3((oldline.transform.localPosition.x - (oldtext.bounds.size.x + 1)), 0.0f, 0.0f);
				}
				else{
					newline.transform.localPosition = new Vector3(oldline.transform.localPosition.x + oldtext.bounds.size.x + 1, 0.0f, 0.0f);
				}
			}
    	}
    	lines.Add(newline);
    }

    GameObject CreateNewText(){
        GameObject balls = (GameObject) Instantiate(textBase, transformFrom.transform.position, transformFrom.transform.rotation, transformFrom);
    	return balls;
    }
}
