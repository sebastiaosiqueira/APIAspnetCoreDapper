using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaltaStore.Shared.Commands
{
    public interface ICommand
    {
        bool Valid();
    }
}