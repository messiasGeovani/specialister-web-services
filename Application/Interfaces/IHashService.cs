using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IHashService
    {
        string Encrypt(string key);

        string EncryptPassword(string key);

        bool Compare(string hash, string key);
    }
}
