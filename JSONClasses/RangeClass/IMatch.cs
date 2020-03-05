using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public interface IMatch
    {
        bool Success();
        string RemainingText();
    }
}
