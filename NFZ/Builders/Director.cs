using NFZ.Models;

namespace NFZ.Builders
{
    public class Director
    {
        public void Construct(Builder builder)
        {           
            builder.BuildDocument();
        }
    }
}
