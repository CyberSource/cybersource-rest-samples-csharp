//using System;
//using System.IO;

//namespace SampleCode.data
//{
//    public class RequestData
//    {
//        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

//        public string JsonFileData(string path)
//        {
//            if (string.IsNullOrEmpty(path))
//            {
//                throw new Exception($"Error: Empty/Null Path provided to JsonFileData Function");
//            }

//            Console.WriteLine($"\n Using Payload of the Json File at:{Path.GetFullPath(path)}");
//            _logger.Trace($"Using Payload of the Json File at:{Path.GetFullPath(path)}");

//            try
//            {
//                using (var r = new StreamReader(path))
//                {
//                    return r.ReadToEnd();
//                }
//            }
//            catch (FileNotFoundException)
//            {
//                throw new Exception($"Error: Request Json File missing. File Path :: {path}");
//            }
//        }

//        public string SamplePaymentsData()
//        {
//            // Create the Sample Data using Model Classes of Payments API
//            Console.WriteLine("\n Using sample Payload of Payments");
//            _logger.Trace("Using sample Payload of Payments");

//            var clientReferenceInformation = new ClientReferenceInformation { code = "TC50171_3" };

//            var processingInformation = new ProcessingInformation { commerceIndicator = "internet" };

//            var subMerchant = new SubMerchant
//            {
//                cardAcceptorID = "1234567890",
//                country = "US",
//                phoneNumber = "650-432-0000",
//                address1 = "900 Metro Center",
//                postalCode = "94404-2775",
//                locality = "Foster Cit",
//                name = "Visa Inc",
//                administrativeArea = "CA",
//                region = "PEN",
//                email = "test@cybs.com"
//            };

//            var aggregatorInformation = new AggregatorInformation
//            {
//                subMerchant = subMerchant,
//                name = "V-Internatio",
//                aggregatorID = "123456789"
//            };

//            var billTo = new BillTo
//            {
//                country = "US",
//                lastName = "VDP",
//                address2 = "Address 2",
//                address1 = "201 S. Division St.",
//                postalCode = "48104-2201",
//                locality = "Ann Arbor",
//                administrativeArea = "MI",
//                firstName = "RTS",
//                phoneNumber = "999999999",
//                district = "MI",
//                buildingNumber = "123",
//                company = "Visa",
//                email = "test@cybs.com"
//            };

//            var amountDetails = new AmountDetails
//            {
//                totalAmount = "102.21",
//                currency = "USD"
//            };

//            var orderInformation = new OrderInformation
//            {
//                billTo = billTo,
//                amountDetails = amountDetails
//            };

//            var card = new Card
//            {
//                expirationYear = "2031",
//                number = "5555555555554444",
//                securityCode = "123",
//                expirationMonth = "12",
//                type = "002"
//            };

//            var paymentInformation = new PaymentInformation { card = card };

//            var payments = new Payments
//            {
//                clientReferenceInformation = clientReferenceInformation,
//                processingInformation = processingInformation,
//                aggregatorInformation = aggregatorInformation,
//                orderInformation = orderInformation,
//                paymentInformation = paymentInformation
//            };

//            return JsonConvert.SerializeObject(payments, Formatting.Indented);
//        }
//    }
//}
