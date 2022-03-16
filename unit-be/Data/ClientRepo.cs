using System;
using System.Collections.Generic;
using unit_be.Models;

namespace unit_be.Data
{
    public static class ClientRepo
    {
        public static List<Client> clients = new List<Client>();
        public static int counterId = 0;
    }
}
