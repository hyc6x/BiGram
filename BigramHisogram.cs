//Sample code developed by Chy Yang
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace BigramHisogram
{
	class BiHistogram 
	{
        	public static void Main() 
        	{
	    		String testFilePath = "";
	    		String line = "";
			
            		Console.Write("Do you have your own test file /(Y/N/)? ");
            		String testFile = Console.ReadLine();
			
			if (testFile == "Y" || testFile == "y") 
			{
				Console.Write("\r\nPlease specify path and file name: ");
				testFilePath = Console.ReadLine();
			}
			else 
			{
				string text = "The big red dog followed the man with the big red hat " +
					"into the big house. ";
                       
				System.IO.File.WriteAllText(@"C:\\codeSample\\ProgramCreatedFile.txt", text);
				testFilePath = "c:\\codeSample\\ProgramCreatedFile.txt";
			}

			try
			{	// Use stream reader to open .txt file
				using (StreamReader sr = new StreamReader(testFilePath))
				{
					// Read the stream input to a string
					line = sr.ReadToEnd();
					Console.WriteLine("\n" + line);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
	                
	                //Regex to create individual words from the stream
	                string pattern = @"\b\w+";
			Regex individualWord =  new Regex (pattern);
			
			List<string> words = new List<string>();
			List<string> bigram = new List<string>();
			List<string> histogram = new List<string>();
			
			//Loop through the collection of individualWord to create a new words list
			foreach (Match match in individualWord.Matches(line))
			{
				words.Add(match.Value);
			}
		
			//Loop through words list to create bigrams and store in bigram List
    			for (int i = 0; i < words.Count; i++)
        	        {				        
			        if (i <= words.Count-2)
			        	bigram.Insert(i, words[i].ToLower() + " " + words[i+1].ToLower());
    			}
    			
    			//Loop through bigram list to count number of occurance of bigram items and create histogram
    			for (int i = 0; i < bigram.Count; i++)
			{
				int j=0;
			
				foreach (string item in bigram)
    				{
    					if(item.ToLowerInvariant().Equals(bigram[i].ToLowerInvariant()))
    						j += 1;
    				}
    				
				histogram.Insert(i, bigram[i] + ", " + j);
    			}
    
    			//Delete duplicates entry in the histogram list.
    			List<string> distinctHistogram = histogram.Distinct().ToList();
			
			Console.WriteLine("");
			
    			foreach (string value in distinctHistogram)
    	                	Console.WriteLine(value);
		}
	}
}
