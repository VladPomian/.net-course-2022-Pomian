using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Exceptions;

namespace Services
{
    public interface IStorage
    {
        public void Add(Client person);
        public void Upd();
        public void Del();
    }
}
