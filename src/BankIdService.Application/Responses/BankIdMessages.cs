using System;
using System.Collections.Generic;
using System.Text;

namespace BankIdService.Application.Responses
{
    public class BankIdMessages
    {
        public const string RFA1 = "Starta BankID-appen";
        public const string RFA2 = "Du har inte BankID-appen installerad.Kontakta din internetbank";
        public const string RFA3 = "Åtgärden avbruten. Försök igen";
        public const string RFA4 = "En identifiering eller underskrift för det här personnumret är redan påbörjad.Försök igen";
        public const string RFA5 = "Internt tekniskt fel. Försök igen.";
        public const string RFA6 = "Åtgärden avbruten.";
        public const string RFA8 = "BankID-appen svarar inte. Kontrollera att den är startad och att du har internetanslutning.Om du inte har något giltigt BankID kan du hämta ett hos din Bank.Försök sedan igen";
        public const string RFA9 = "Skriv in din säkerhetskod i BankID-appen och välj Legitimera eller Skriv under";
        public const string RFA13 = "Försöker starta BankID-appen.";
        public const string RFA14_A = "Söker efter BankID, det kan ta en liten stund… Om det har gått några sekunder och inget BankID har hittats har du sannolikt inget BankID som går att använda för den aktuella identifieringen/underskriften i den här datorn. Om du har ett BankIDkort, sätt in det i kortläsaren. Om du inte har något BankID kan du hämta ett hos din internetbank. Om du har ett BankID på en annan enhet kan du starta din BankID-app där.";
        public const string RFA14_B = "Söker efter BankID, det kan ta en liten stund… Om det har gått några sekunder och inget BankID har hittats har du sannolikt inget BankID som går att använda för den aktuella identifieringen/underskriften i den här enheten. Om du inte har något BankID kan du hämta ett hos din internetbank. Om du har ett BankID på en annan enhet kan du starta din BankID-app där.";
        public const string RFA16 = "Det BankID du försöker använda är för gammalt eller spärrat. Använd ett annat BankID eller hämta ett nytt hos din internetbank.";
        public const string RFA20 = "Vill du identifiera dig eller skriva under med ett BankID på den här enheten eller med ett BankID på en annan enhet?";
        public const string RFA21 = "Identifiering eller underskrift pågår";
        public const string RFA22 = "Okänt fel. Försök igen";
    }
}
