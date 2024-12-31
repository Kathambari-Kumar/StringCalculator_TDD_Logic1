using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
public class String_Calc
{
        public int Add(string input_str)
        {
            string temp_str = null; // temporary string for concatenation purpose
            // creating a list and temporary list
            List<string> number_List = new List<string>();
            List<string> temp_List = new List<string>();
            int result; // to store the sum
            if (string.IsNullOrEmpty(input_str))
                return 0;
            else
            {
                // getting only the numbers from the input string
                // by checking the extracted character is number or not
                for (int i = 0; i < input_str.Length; i++)
                {
                    if (char.IsDigit(input_str[i]) || input_str[i] == '-')
                    {
                        Console.WriteLine("Character in String : {0}", input_str[i]);
                        // concatenating characters if it is more than 1 digit
                        // untill the next character is not a number
                        temp_str = temp_str + input_str[i].ToString();
                    }
                    else
                    {
                        // number is added to a list if it contains number
                        if (temp_str != null)
                        {
                            number_List.Add(temp_str.ToString());
                            // making the temporary string to empty
                            // for the next number
                            temp_str = null;
                        }
                    }
                }
            }
            // this is to add the last number into list
            // b'coz loop ends without adding last number
            if (temp_str.Any())
            {
                number_List.Add(temp_str.ToString());
            }
            
            // moving the list elements [numbers] into temporary list
            for (int i = 0; i < number_List.Count; i++)
            {
                // b'coz of the condition to add negative numbers
                // maybe '-' is added to the list as a string
                // this code helps to remove it
                if (number_List.ElementAt(i) != "-")
                    temp_List.Add(number_List.ElementAt(i).ToString());
            }

            // creating a string array with the size of temporary list
            // contains only numbers and moving it into the string list
            string[] str_List = new string[temp_List.Count];
            for (int i = 0; i < temp_List.Count; i++)
            {
                str_List[i] = temp_List.ElementAt(i).ToString();
            }
            // explicit type casting 
            var numbers = str_List.Select(int.Parse);
            // checking weather the number array has negatives or not
            // and if it has negatives, this code throws an exception
            var negatives = numbers.Where(n => n < 0);
            if (negatives.Any())
            {
                if (negatives.Count() == 1)
                    throw new Exception("Negatives are not allowed");
                else
                    throw new Exception($"Negatives are not allowed : {string.Concat(negatives)}");
            }
            else
            {
                // extracting number which is less than or equal to 1000
                // and finding the sum of numbers
                var numbers1 = numbers.Where(n => n <= 1000);
                result = numbers1.Sum();
            }
            return result; // returning the result
        }
    }
}
