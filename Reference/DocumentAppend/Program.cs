﻿using System;
using System.IO;
using System.Reflection;
using O2S.Components.PDF4NET;
using O2S.Components.PDF4NET.Samples;

namespace O2S.Components.PDF4NET.Samples.NetCore
{
    class DocumentAppend
    {
        static void Main(string[] args)
        {
            string supportPath = "..\\..\\..\\..\\..\\SupportFiles\\";

            
            FileStream file1Input = new FileStream(supportPath + "content.pdf", FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream file2Input = new FileStream(supportPath + "formfill.pdf", FileMode.Open, FileAccess.Read, FileShare.Read);
            SampleOutputInfo[] output = O2S.Components.PDF4NET.Samples.DocumentAppend.Run(file1Input, file2Input);
            file1Input.Dispose();
            file2Input.Dispose();
            

            for (int i = 0; i < output.Length; i++)
            {
				FileStream outStream = File.OpenWrite(output[i].FileName);
                output[i].Document.Save(outStream, output[i].SecurityHandler);
				outStream.Flush();
				outStream.Dispose();
            }

            Console.WriteLine("File(s) saved with success to current folder.");
        }
    }
}
