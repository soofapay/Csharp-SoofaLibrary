**SOOFA PAY**
This is the soofapay library for .NET and .NET core.You can use it asp.net mvc,asp.net core and asp.net mvc.
**To get started**
install the package from the nuget package manage

`Install-Package SoofaPay`

Or install Via CLI or terminal as:

`dotnet add package SoofaPay`

 import the library as shown below in your working class

`using Soofa;`

Then in your method call the code below to instantiate the soofapay class:

```ISoofaPay soofa = new SoofaPay(till_no, client_secret);```

**Check for Transaction**
The transaction method allows you to check the status of a transaction it returns a transaction object.You will need to pass a transaction id as shown below.

```   var transaction = soofa.GetTransaction(transaction_id);```

Below is a sample transaction object that you will receive.
**NOTE:** It is a C# class object not a json object the .
```
{
    "status": "SUCCESSFUL",
    "sender_currency": "KES",
    "receiver_currency": "KES",
    "tid": "QTMB3",
    "reference": "T5002",
    "receipt_no": "NFQ6U45W28",
    "timestamp": 1561499777.715254,
    "gross_amount": 5,
    "net_amount": 4.8605,
    "transacted_via": "mpesa",
    "is_money_in": true,
    "sender": "+254721732519",
    "receiver": "Dev Market"
}
```

**Check for Balance**

To check for balance call the method below

```var balance = soofa.GetBalance();```

You will receive the C# object below

```
{ 
   "balance": "1587.49", 
   "currency": "KES", 
   "timestamp": 1561820831.623298
}
```

**Console App example**
```
using Soofa;
using System;

namespace SoofaConsoleAppTest
{
    class Program
    {
      
        static void Main(string[] args)
        {
            string till_no = "Your till Number";
            string client_secret = "Your soofapay client secret";

            ISoofaPay soofa = new SoofaPay(till_no, client_secret);
            //Gets balance
            var balance = soofa.GetBalance();
            Console.WriteLine(balance.currency);
            string transaction_id = "transaction id";
            //Gets Transaction from a given Transaction Id

            var transaction = soofa.GetTransaction(transaction_id);
            Console.WriteLine(transaction.gross_amount);
          
         }
    }
}
```
**_Explanation of The Transaction object_**

**status:** The state of the transaction, either SUCCESSFUL or PENDING

**sender\_currency:** The currency of the person who performed the transaction

**receiver\_currency:** The currency of the business, if the transaction was Money in for the business

**reference:** The transaction reference passed when making a transaction

**timestamp:** Unix timestamp for the transaction

**gross\_amount:** The amount of the transaction

**net\_amount:** The amount received after deducting soofa

**transacted\_via:** The service provider which facilitated the transaction eg. mpesa, visa, airtelmoney, mastercard, tkash

**is\_money\_in:** A boolean indicating if the money was to the business or out of the business

**sender:** The performer of transaction

**receiver:** The receiver of the transaction which is the business if the transaction was inbound
