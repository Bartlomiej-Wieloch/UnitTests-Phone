using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public class Phone
    {
        private string owner;
        // string of 9 digits
        private string phoneNumber;
        // Dictionary of <name, number>
        private readonly Dictionary<string, string> phoneBook;
        public int PhoneBookCapacity => 100;                //autoproperty które zawsze wynosi 100

        public Phone(string owner, string phoneNumber)      //konstruktor, nazwa taka sama jak nazwa klasy i brak typu zwrotnego
        {
            Owner = owner;
            PhoneNumber = phoneNumber;
            phoneBook = new Dictionary<string, string>();
        }

        public string Owner                                 //proprerty
        {
            get => owner;       
            private set                                     //private set - tylko wewn¹trz klasy mo¿na tego u¿yæ
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException($"Owner name is empty or null!");

                owner = value;
            }
        }

        private bool IsCorrectPhoneNumber(string number)    //strzalka = zwracam wynik uzyskany za pomoc¹ po³¹czeñ logicznych - uproszczenie aby nie u¿ywaæ { return }
            => (number != null) && number.Length == 9 && number.All(c => char.IsDigit(c));      //¿eby nie mo¿na by³o ich u¿yæ na zewn¹trz

        public string PhoneNumber
        {
            get => phoneNumber;
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException($"Phone number is empty or null!");

                if (!IsCorrectPhoneNumber(value))       
                    throw new ArgumentException($"Invalid phone number!");

                phoneNumber = value;
            }
        }

        public int Count => phoneBook.Count;            

        public bool AddContact(string name, string number)
        {
            if (Count == PhoneBookCapacity)
                throw new InvalidOperationException("Phonebook is full!");

            if (!phoneBook.ContainsKey(name))
            {
                phoneBook.Add(name, number);
                return true;
            }

            return false;
        }

        public string Call(string name)
        {
            if (phoneBook.ContainsKey(name))
            {
                var number = phoneBook[name];
                return $"Calling {number} ({name}) ...";
            }

            throw new InvalidOperationException("Person doesn't exists!");
        }
    }
}
