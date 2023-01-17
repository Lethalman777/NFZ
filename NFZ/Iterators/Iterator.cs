using NFZ.Entities;
using NFZ.Services;
using System.Web;

namespace NFZ.Iterators
{
    public class Iterator : IIterator
    {
        public int currentNumber = 1;
        public bool isInvoice;
        public IDatabaseService dbservice;

        public Iterator(IDatabaseService dbservice)
        {
            this.dbservice = dbservice;
        }

        public Document First()
        {
            int firstNumber = 1;
            while (GetDocument(firstNumber) == null)
            {
                firstNumber++;
            }

            return GetDocument(currentNumber);
        }

        public void Next()      //Metoda zwraca nastepny numer dokumentu
        {
            while (GetDocument(currentNumber + 1) == null)
            {
                currentNumber++;
            }

            currentNumber++;
        }

        public bool isDone()        //Metoda sprawdza czy lista dokumentów na końcu 
        {
            if (GetDocument(currentNumber + 1) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Document CurrentDocument()   //Zwraca dokument o numerze podanym jako parametr currentNumber
        {
            return GetDocument(currentNumber);
        }

        private Document GetDocument(int number)   //Pobiera dokument z bazy danych o numerze podanym w 
        {                                          //parametrze number
            return dbservice.GetDocument(number, isInvoice);
        }
    }
}
