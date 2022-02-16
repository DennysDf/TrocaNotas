using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecSaudeAH.Services.Interfaces
{
    public interface INotificacao
    {
        void Success(string message);
        void Error();
    }
}
