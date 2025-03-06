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

            //Assert.ThrowsException<ArgumentException>(() => new Phone(wlasciciel, numer));
        }
    }
    class Pomocniczna
    {

    }
}