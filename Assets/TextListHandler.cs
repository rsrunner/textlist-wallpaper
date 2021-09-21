using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextListHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public static List<string> Quotes = new List<string>();

    public List<string> GetQuotes(){
    	return Quotes;
    }

    void Start()
    {
    	Directory.CreateDirectory("Textlists/");
        DirectoryInfo directory = new DirectoryInfo("Textlists/");
        FileInfo[] info = directory.GetFiles("*.txt");
        foreach(FileInfo file in info){
        	string contents = "";
        	using(StreamReader sr = file.OpenText()){
        		string chunk = "";
        		while((chunk = sr.ReadLine()) != null){
        			if(chunk.Length >= 1){
        				contents += chunk + "\n";
        				Quotes.Add(chunk);
        			}
        		}
        	}
        	Debug.Log(String.Format("Added textlist {0}", file.Name));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
