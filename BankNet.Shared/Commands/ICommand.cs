using System;
using System.Collections.Generic;
using System.Text;

namespace BankNet.Shared.Commands
{
    public interface ICommand
    {
        bool Valid();
    }
}
