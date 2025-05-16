using CinemaApp.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAPp.UI.Utils;

public static class JsonParser
{
    public static string SerializeTicket(Ticket ticket)
    {
        if (ticket == null)
            throw new ArgumentNullException(nameof(ticket));

        return JsonConvert.SerializeObject(ticket);
    }

    public static Ticket DeserializeTicket(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
            throw new ArgumentException("Input JSON string cannot be null or empty.", nameof(json));

        return JsonConvert.DeserializeObject<Ticket>(json)
               ?? throw new InvalidOperationException("Deserialization resulted in null.");
    }
}
