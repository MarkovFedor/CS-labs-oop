using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.Clients
{
    public interface IBuilder
    {
        IBuilder Create();
        IBuilder AddName(string name);
        IBuilder AddSurname(string surname);
        IBuilder AddPassport(string passport);
        IBuilder AddAddress(string address);
        Client Build();
    }
}
