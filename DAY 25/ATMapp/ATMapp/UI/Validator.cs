using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ATMapp.UI
{
    public static class Validator
    {
        public static T Convert<T>(string prompt)
        {
            bool valid = false;
            string userInput;

            while (!valid)
            {
                userInput = Utility.GetUserInput(prompt);

                try
                {
                    //this converter variable 
                    var converter = TypeDescriptor.GetConverter(typeof(T));
                    if(converter != null)
                    {
                        return (T)converter.ConvertFromString(userInput);
                    }
                    //this else block will execute if the given type by user cannot be converted into the specified type - i.e.wrong input type
                    else
                    {
                        return default;
                    }
                }
                catch
                {
                    Utility.PrintMessage("Invalid Input. Try Again.", false);
                }
            }
            return default;
        }
    }
}
