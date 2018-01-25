using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TesteSonar
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecutarComando(args[0]);

        }


       static void ExecutarComando(string id)
        {
            Regex rgx = new Regex(@"^[a-zA-Z0-9]+$");
            // PRJ-2017-0000760 correção CWE ID 78 
            if (rgx.IsMatch(id))
            {
                string strArgs = String.Format(@"/x {0} /passive",id);
                Process p = new Process { StartInfo = { FileName = "msiexec.exe", Arguments = strArgs } };
                p.Start();
                p.WaitForExit();
                if (p.ExitCode == 0)
                {
                    Console.WriteLine("Sucesso!");

                }
                else
                {
                    Console.WriteLine("Erro na execução");

                }
            }

        }
    }
}
