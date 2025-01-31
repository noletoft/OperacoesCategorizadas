
/*
    Caso o usuario entrar com dados inesperados, este sera orientado a entrar com o valor correto.
*/

using System.Globalization;
using OperacoesCategorizadas.Interfaces;
using OperacoesCategorizadas.Models;

namespace OperacoesCategorizadas.Manager
{
    public class ValidatorManager
    {
        public DateTime GetDataValida(string mensagem)
        {
            DateTime validDate = DateTime.MinValue;
            bool ehValido = false;            

            while (!ehValido)
            {
                try
                {                    
                    Console.Write(mensagem);
                    validDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture);                    
                    ehValido = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Invalid Date! Please enter a date in the MM/dd/yyyy format.");                    
                }
            }

            return validDate; 
        }

        public int GetOperacoesValida(string mensagem)
        {
            int nOperacoes = 0;
            bool ehValido = false;
           
            while (!ehValido)
            {
                try
                {                    
                    Console.Write(mensagem);
                    nOperacoes = int.Parse(Console.ReadLine());                    
                    ehValido = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"The number of trades are wrong!, enter the total of trades to be processed (1 a n).");                    
                }
            }

            return nOperacoes; 
        }

        public Trade ValidaOperacao(string mensagem)
        {
            Trade tResult = null;            
            string errorParts = string.Empty;
            bool isValid = false;
                        
            while (!isValid)
            {
                try
                {                    
                    Console.Write(mensagem);                    
                    string[] operacaoComponentes = Console.ReadLine().Split(' ');

                    if(operacaoComponentes.Length != 3)
                    {
                        throw new Exception($"It's expected 3 trade's parts, however, it has '{operacaoComponentes.Length}'");
                    }

                    try
                    {
                        double.Parse(operacaoComponentes[0]);                        
                    }   
                    catch(Exception){
                        errorParts = "tradeValue";
                    } 
                    
                    errorParts = operacaoComponentes[1] != "Public" && operacaoComponentes[1] != "Private" ? errorParts += " clientSector" : errorParts;

                    try
                    {
                        DateTime.ParseExact(operacaoComponentes[2], "MM/dd/yyyy", CultureInfo.InvariantCulture);                         
                    }   
                    catch(Exception)
                    {
                        errorParts += " nextPaymentDate";
                    }

                    if(errorParts.Length != 0)
                    {                        
                        var msg = $"The following trade's parts are wrong: {errorParts}";
                        errorParts = string.Empty;
                        throw new Exception(msg);
                    }
                    else
                    {
                        tResult = new Trade(
                            double.Parse(operacaoComponentes[0]),
                            operacaoComponentes[1],
                            DateTime.ParseExact(operacaoComponentes[2], "MM/dd/yyyy", null)
                        ); 

                        isValid = true;                        
                    }                    
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("");
                    Console.WriteLine(e.Message);                    
                }
            }         

            return tResult; 
        }
        
    }
}