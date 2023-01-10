using NFZ.Entities;
using NFZ.Services;
using System.Web;

namespace NFZ.Iterators
{
    public class Iterator : IIterator
    {
        public int currentNumber = 1;
        public bool isInvoice;
        IDatabaseService dbservice;

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

        public void Next()
        {
            while (GetDocument(currentNumber + 1) == null)
            {
                currentNumber++;
            }

            currentNumber++;
        }

        public bool isDone()
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

        public Document CurrentDocument()
        {
            return GetDocument(currentNumber);
        }

        private Document GetDocument(int number)
        {
            return dbservice.GetDocument(number, isInvoice);
        }
    }
}
