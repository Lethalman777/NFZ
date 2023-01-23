using NFZ.Entities;

namespace NFZ.Builders
{
    public abstract class PerfectDocumentBuilder //Abstrakcyjna klasa po której dziedziczą PerfectInvoiceBuilder 
    {                                            //i PerfectReceiptBuilder
        public abstract void BuildDocument();
        public abstract Document GetDocument();
        public abstract void SetProducts();
        public abstract void SetCompanyInfo();
        public abstract void SetClientInfo();
        public abstract void SetOrderInfo();
        public abstract void SetWorkerInfo();
    }
}
