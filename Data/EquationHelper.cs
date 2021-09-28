using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace NEA
{
    public class EquationHelper
    {
    
        public List<Double> RemoveAdditionSign(string A, string B, string C){
            List<Double> parts = new List<Double>();
            try{
                Double partA = Convert.ToDouble(A);
                parts.Add(partA);

            }
            catch{
                parts.Add(1);
            }
            
            try{
                Double partB = Convert.ToDouble(B); //checks for a negative value
                parts.Add(partB);
            }
            catch{
                Double partB = Convert.ToDouble(B[1]); //if the value has a + symbol 
                parts.Add(partB);
            }
            try{
                Double partC = Convert.ToDouble(C);
                parts.Add(partC);
            }
            catch{
                Double partC = Convert.ToDouble(C[1]);
                parts.Add(partC);
            }
            return parts;
        }

        public static readonly Regex QuadraticRegex = new (@"(?:(?<A>-?(\d+)?) ?x\^2)(?<B>[+-] ?(\d?)+) ?x(?<C>[+-] ?\d+)?", RegexOptions.IgnoreCase | RegexOptions.Compiled, 
        TimeSpan.FromMilliseconds(250));

        public static readonly Regex LinearRegex = new (@"(?<B>-? ?(\d?)+) ?x(?<C>[+-] ?\d+)?", RegexOptions.IgnoreCase | RegexOptions.Compiled, 
        TimeSpan.FromMilliseconds(250));
        public List<double> ParseEquationRegex(string equation){
            equation = equation.Replace(" ", string.Empty);
            Match m = QuadraticRegex.Match(equation); //applies the regex to the inputted equation
            string A;
            string B;
            string C;
            if (m.Success){        
                A = m.Groups["A"].Value; //gets each numerical value from the equation into their corresponding letters from ax^2+bx+c
                B = m.Groups["B"].Value;
                C = m.Groups["C"].Value;
                if (A == null){
                    A = "1"; //this applies to equations with no coefficient of x^2
                }
                else if (A == "-"){
                    A = "-1"; //E.g -x^2+bx+c
                }
                if (B == "+"){
                    B = "+1";
                }
                else if (B == "-"){
                    B = "-1";
                }
                if (C == null){
                    C = "0"; //Equations in the form ax^2+bx need to assign 0 to C
                }
                List<Double> parts = new List<Double>();
                parts = RemoveAdditionSign(A,B,C); //The regex leaves - and + signs with each number so to convert to a double we must remove the + sign
                return parts;
                
            }
            else{
                m = LinearRegex.Match(equation);  
                A = "0";       
                B = m.Groups["B"].Value;
                C = m.Groups["C"].Value;
                
            
                if (B == "-"){
                    B = "-1";
                }
                if (C == null){
                    C = "0";
                }
                List<Double> parts = new List<Double>();
                parts = RemoveAdditionSign(A,B,C);               
                return parts;      
            }   
        } 
        public List<double> ParseEquation(string equation){
            double A = 0;
            double B = 0;
            double C = 0;
            List<string> positiveParts =  new List<string>();
            List<string> negativeParts =  new List<string>();
            string[] additionSplitString = equation.Split("+");

            try
            {
                foreach (var positivePart in additionSplitString)
                {
                    if (Convert.ToString(positivePart[0]) != "-")
                    {
                        positiveParts.Add(positivePart.Split("-")[0]);
                        if (positivePart.Contains("-"))
                        {   
                            string[] subtractionSplitString = positivePart.Split("-");
                            for (int i = 1; i < subtractionSplitString.Length; i++)
                            {
                                negativeParts.Add(subtractionSplitString[i]);
                            }
                        }
                    }
                    else
                    {
                        string[] subtractionSplitString = positivePart.Split("-");
                        foreach (var negativePart in subtractionSplitString)
                        {
                            negativeParts.Add(negativePart);
                        }
                    }
                }
                if (negativeParts.Contains(""))
                {
                    negativeParts.Remove("");
                }

                foreach (var positivePart in positiveParts)
                {
                    if (positivePart.Contains("x^2"))
                    {
                        int positionOfX = positivePart.IndexOf("x");
                        char[] charArray = positivePart.ToCharArray();
                        if (charArray[0] == 'x')
                        {
                            A = 1;
                        }
                        else
                        {
                            A = Convert.ToDouble(positivePart.Substring(0,positionOfX));
                        }
                    }
                    else if(positivePart.Contains("x"))
                    {
                        int positionOfX = positivePart.IndexOf("x");
                        char[] charArray = positivePart.ToCharArray();
                        if (charArray[0] == 'x')
                        {
                            B = 1;
                        }
                        else
                        {
                            B = Convert.ToDouble(positivePart.Substring(0,positionOfX));
                        }
                    }
                    else
                    {
                        C = Convert.ToDouble(positivePart);
                    }  
                }

                foreach (var negativePart in negativeParts)
                {
                    if (negativePart.Contains("x^2"))
                    {
                        int positionOfX = negativePart.IndexOf("x");
                        char[] charArray = negativePart.ToCharArray();
                        if (charArray[0] == 'x')
                        {
                            A = -1;
                        }
                        else
                        {
                            A = 0 - Convert.ToDouble(negativePart.Substring(0,positionOfX));
                        }
                    }
                    else if(negativePart.Contains("x"))
                    {
                        int positionOfX = negativePart.IndexOf("x");
                        char[] charArray = negativePart.ToCharArray();
                        if (charArray[0] == 'x')
                        {
                            B = -1;
                        }
                        else
                        {
                            B = 0 - Convert.ToDouble(negativePart.Substring(0,positionOfX));
                        }
                    }
                    else
                    {
                        C = 0 - Convert.ToDouble(negativePart);
                    }  
                }
                List<Double> parts = new List<Double>();
                parts.Add(A);
                parts.Add(B);
                parts.Add(C);

                return parts;
            }

            catch
            {
                Console.WriteLine("Invalid entry, please try again");
                return null;
            }


        }
        public List<string> SolveEquation(double A, double B, double C){
            List<string> solutions = new List<string>();
            string solution1 = ""; //Quadratics have two solutions
            string solution2 = "";
            try{
                if (A != 0) //If the equation is a quadratic
                {
                    Double discriminant = B*B - 4*A*C; //use the quadratic formula
                    Double squareRoot = Math.Sqrt(Math.Abs(discriminant));
                    if (discriminant >= 0)
                    {
                        Double root1 = (-B + squareRoot)/(2*A);
                        Double root2 = (-B - squareRoot)/(2*A);
                        root1 = Math.Round(root1, 2); //Round the root to 2dp
                        root2 = Math.Round(root2, 2);
                        if (root1 == root2) //If both roots are the same
                        {
                            solution1 = Convert.ToString(root1);
                            solution2 = solution1;
                        }
                        else
                        {
                            solution1 = Convert.ToString(root1);;
                            solution2 = Convert.ToString(root2);;
                        }
                    }
                    else //If the roots are imaginary numbers they require more formatting
                    {
                        Double coefficient = (squareRoot)/(2*A);
                        Double roundedCoefficient = Math.Round(coefficient,2);
                        solution1 = ((-B)/(2*A) + " + " + roundedCoefficient + "i");
                        solution2 = ((-B)/(2*A) + " - " + roundedCoefficient + "i");
                    }
                    solutions.Add(solution1);
                    solutions.Add(solution2);
                }
                else //If the equation is linear
                {
                    double root = (-C)/B;
                    Math.Round((decimal)root, 2);
                    solution1 = Convert.ToString(root);
                    solutions.Add(solution1);
                } 
            }
            catch{
                double root = C;
                string solution = Convert.ToString(root);
                solutions.Add(solution);
            }
            return solutions;
        }
    }
}
