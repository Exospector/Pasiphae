//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.34014
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.IO;
using UnityEngine;
using System.Text;


namespace AssemblyCSharp
{
	public class Dialogue
	{
		public Dialogue ()
		{

		}
	
	public byte[] FromHex(string hex)
	{
		hex = hex.Replace(" ", "");
		byte[] raw = new byte[hex.Length / 2];
		for (int i = 0; i < raw.Length; i++)
		{
			raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
		}
		return raw;
	}
		public String[] open(string filename){
			TextAsset sr = Resources.Load<TextAsset> (filename);
			String fileContents = sr.text;
			String[] lines = fileContents.Split ("\n" [0]);
			return lines;

		}
		public string[] ReadLine(String line){
			byte[] data=FromHex (line);
			string decrypt=Encoding.ASCII.GetString (data);
			string [] info=decrypt.Split ('>');
			string name = info [0].Substring (1);
			string[] text = info [1].Split ('<');
			string[] retour= new string [2];
			retour [0] = name;
			retour [1] = text [0];
			return retour;
		}
	}
}
