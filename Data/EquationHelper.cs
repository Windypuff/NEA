using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace NEA
{
    public class EquationHelper
    {
    
        public List<Decimal> RemoveAdditionSign(string A, string B, string C){
            List<Decimal> parts = new List<Decimal>();
            try{
                Decimal partA = Convert.ToDecimal(A);
                parts.Add(partA);

            }
            catch{
                parts.Add(1);
            }
            
            try{
                Decimal partB = Convert.ToDecimal(B); //checks for a negative value
                parts.Add(partB);
            }
            catch{
                Decimal partB = Convert.ToDecimal(B[1]); //if the value has a + symbol 
                parts.Add(partB);
            }
            try{
                Decimal partC = Convert.ToDecimal(C);
                parts.Add(partC);
            }
            catch{
                Decimal partC = Convert.ToDecimal(C[1]);
                parts.Add(partC);
            }
            return parts;
        }

        public static readonly Regex QuadraticRegex = new (@"(?:(?<A>-?(\d+)?) ?x\^2)(?<B>[+-] ?(\d?)+) ?x(?<C>[+-] ?\d+)?", RegexOptions.IgnoreCase | RegexOptions.Compiled, 
        TimeSpan.FromMilliseconds(250));

        public static readonly Regex LinearRegex = new (@"(?<B>-? ?(\d?)+) ?x(?<C>[+-] ?\d+)?", RegexOptions.IgnoreCase | RegexOptions.Compiled, 
        TimeSpan.FromMilliseconds(250));
        public List<decimal> ParseEquationRegex(string equation){
            
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
                List<Decimal> parts = new List<Decimal>();
                parts = RemoveAdditionSign(A,B,C); //The regex leaves - and + signs with each number so to convert to a decimal we must remove the + sign
                return parts;
                
            }
            else{
                m = LinearRegex.Match(equation);  
                A = "0";       
                B = m.Groups["B"].Value;
                C = m.Groups["C"].Value;
                
                if (B == ""){
                    B = "1";
                }
                else if (B == "-"){
                    B = "-1";
                }
                if (C == null){
                    C = "0";
                }
                List<Decimal> parts = new List<Decimal>();
                parts = RemoveAdditionSign(A,B,C);               
                return parts;      
            }   
        } 
        public List<decimal> ParseEquation(string equation){
            decimal A = 0;
            decimal B = 0;
            decimal C = 0;
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
                            A = Convert.ToDecimal(positivePart.Substring(0,positionOfX));
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
                            B = Convert.ToDecimal(positivePart.Substring(0,positionOfX));
                        }
                    }
                    else
                    {
                        C = Convert.ToDecimal(positivePart);
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
                            A = 0 - Convert.ToDecimal(negativePart.Substring(0,positionOfX));
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
                            B = 0 - Convert.ToDecimal(negativePart.Substring(0,positionOfX));
                        }
                    }
                    else
                    {
                        C = 0 - Convert.ToDecimal(negativePart);
                    }  
                }
                List<Decimal> parts = new List<Decimal>();
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

        
        public List<string> SolveEquation(decimal A, decimal B, decimal C){
            List<string> solutions = new List<string>();
            string solution1 = ""; //Quadratics have two solutions
            string solution2 = "";
            try{
                if (A != 0) //If the equation is a quadratic
                {
                    Decimal discriminant = B*B - 4*A*C; //use the quadratic formula
                    Decimal squareRoot = (decimal)Math.Sqrt((double)Math.Abs(discriminant));
                    if (discriminant >= 0)
                    {
                        Decimal root1 = (-B + squareRoot)/(2*A);
                        Decimal root2 = (-B - squareRoot)/(2*A);
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
                        Decimal coefficient = (squareRoot)/(2*A);
                        Decimal roundedCoefficient = Math.Round(coefficient,2);
                        solution1 = (Math.Round((-B)/(2*A),2) + " + " + roundedCoefficient + "i");
                        solution2 = (Math.Round((-B)/(2*A),2) + " - " + roundedCoefficient + "i");
                    }
                    solutions.Add(solution1);
                    solutions.Add(solution2);
                }
                else //If the equation is linear
                {
                    decimal root = (-C)/B;
                    Math.Round((decimal)root, 2);
                    solution1 = Convert.ToString(root);
                    solutions.Add(solution1);
                } 
            }
            catch{
                decimal root = C;
                string solution = Convert.ToString(root);
                solutions.Add(solution);
            }
            return solutions;
        }

        public decimal? FindTurningPoint (decimal A, decimal B, decimal C)
        {
            //find equation in form (x-b)^2 + c
            if (A == 1){
                decimal b = B/2;
                decimal c = C-(b*b);  
                decimal turningPoint;
                turningPoint = b*-1;     
                return turningPoint;   
            }
            if ((A != 1) && (A != 0)){
                //find in form A[x^2+b]+C
                decimal b = B / A;
                //find form A(x+b)^2+C
                b = b/2;
                decimal c = C-(A*b*b);
                decimal turningPoint;
                turningPoint = b*-1; 
                return turningPoint;
            }
            else{
                return null;
            }
        }
    }
}