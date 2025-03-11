using ClassLibrary;

namespace TestProjectPhone
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Konstruktor_Dane_Poprawne_OK()      //sama nazwa powinna wystarczyæ aby wiedzieæ co ten kod zrobi
        {
            // AAA

            // Arange
            var wlasciciel = "Bartek";
            var number = "123456789";

            // Act
            var telefon = new Phone(wlasciciel, number);

            // Assert
            Assert.AreEqual(wlasciciel, telefon.Owner);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Konstruktor_ZaKrotkiNumerTelefonu_ArgumentException()
        {
            // AAA

            // Arange
            var wlasciciel = "Bartek";
            var numer = "12345678";

            // Act
            var telefon = new Phone(wlasciciel, numer);

            // Assert

            //Assert.ThrowsException<ArgumentException>(() => new Phone(wlasciciel, numer)); <-albo to, albo 24 linijka
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Konstruktor_BrakNumeruTelefonu_ArgumentException()
        {
            // Arange
            var wlasciciel = "Bartek";
            var numer = "";

            // Act
            var telefon = new Phone(wlasciciel, numer);

            // Assert

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Konstruktor_BrakImienia_ArgumentException()
        {
            // Arange
            var wlasciciel = "";
            var numer = "123456789";

            // Act
            var telefon = new Phone(wlasciciel, numer);

            // Assert

        }
        [TestMethod]
        public void Konstruktor_WywolanieNumeruTelefonuGetterem_Powodzenie()
        {
            // Arange
            var wlasciciel = "Bartek";
            var numer = "123456789";
            var telefon = new Phone(wlasciciel, numer);

            // Act

            // Assert
            Assert.AreEqual(numer, telefon.PhoneNumber);
        }
        [TestMethod]
        public void AddContact_NowyKontakt_Powodzenie()
        {
            // Arange
            var wlasciciel = "Bartek";
            var numer = "123456789";
            var telefon = new Phone(wlasciciel, numer);

            // Act
            telefon.AddContact(wlasciciel, numer);

            // Assert
            Assert.IsTrue(telefon.AddContact("Adam", numer));
        }
        [TestMethod]
        public void AddContact_KontaktJuzIstnieje_NiePowodzenie()
        {
            // Arange
            var wlasciciel = "Bartek";
            var numer = "123456789";
            var telefon = new Phone(wlasciciel, numer);

            // Act
            telefon.AddContact(wlasciciel, numer);

            // Assert
            Assert.IsFalse(telefon.AddContact(wlasciciel, numer));
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddContact_KsiazkaKontakowPelna_Exception()
        {
            // Arange
            var wlasciciel = "Bartek";
            var numer = "123456789";
            var telefon = new Phone(wlasciciel, numer);

            for (int i = 0; i < telefon.PhoneBookCapacity; i++)
            {
                telefon.AddContact(wlasciciel + i, numer);
            }

            // Act
            telefon.AddContact("Adam", numer);

            //telefon.AddContact(wlasciciel, numer);
            // Assert
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Call_KontaktNieIstnieje_NiePowodzenie()
        {
            // Arange
            var wlasciciel = "Bartek";
            var numer = "123456789";
            var telefon = new Phone(wlasciciel, numer);

            // Act
            telefon.Call("Adam");

            // Assert
        }
        [TestMethod]
        public void Call_KontaktIstnieje_Powodzenie()
        {
            // Arange
            var wlasciciel = "Bartek";
            var numer = "123456789";
            var telefon = new Phone(wlasciciel, numer);

            string nowyKontakt = "Adam";
            telefon.AddContact(nowyKontakt, numer);

            // Act

            // Assert
            Assert.AreEqual($"Calling {numer} ({nowyKontakt}) ...", telefon.Call(nowyKontakt));
        }
    }
}