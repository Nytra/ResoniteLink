using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResoniteLink
{
    /// <summary>
    /// Interface for command input/output handling
    /// </summary>
    public interface ICommandIO
    {
        /// <summary>
        /// Reads a command from the console input
        /// </summary>
        /// <returns>
        /// The command read from the input, as the Command enum value
        /// </returns>
        Task<(CommandType, string)> ReadCommand();
        
        /// <summary>
        /// Splits a command string into keyword and arguments, can also be used to split arguments from values as well
        /// </summary>
        /// <param name="command">The full command string to split, or the string to split into keyword and arguments</param>
        /// <param name="keyword">The first word in the command string</param>
        /// <param name="arguments">Any subsequent words in the command string</param>
        void SplitCommand(string command, out string keyword, out string arguments);
        
        /// <summary>
        /// Prints a prompt message to the console in cyan color
        /// </summary>
        /// <param name="prompt">The prompt message to print</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task PrintPrompt(string prompt);
        
        /// <summary>
        /// Prints a message to the console without a newline
        /// </summary>
        /// <param name="message">The message to print</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task Print(string message);
        
        /// <summary>
        /// Prints a message to the console with a newline
        /// </summary>
        /// <param name="message">The message to print</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task PrintLine(string message);
        
        /// <summary>
        /// Prints an error message to the console in red color
        /// </summary>
        /// <param name="message">The error message to print</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task PrintError(string message);
    }
}
