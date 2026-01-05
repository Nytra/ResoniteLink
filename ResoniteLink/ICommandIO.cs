using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResoniteLink
{
    public interface ICommandIO
    {
        Task<string> ReadCommand();
        Task PrintPrompt(string prompt);
        Task Print(string message);
        Task PrintLine(string message);
        Task PrintError(string message);
    }
}
