using Microsoft.EntityFrameworkCore;

namespace NFZ.Entities
{
    public class NFZDbContext : DbContext
    {
        public NFZDbContext(DbContextOptions<NFZDbContext> options) : base(options)
        {
            
        }

        public DbSet<Order> orders { get; set; }
        public DbSet<OrderProduct> orderProducts { get; set; }
        public DbSet<InvoiceProduct> invoiceProducts { get; set; }
        public DbSet<ReceiptProduct> receiptProducts { get; set; }
        public DbSet<Worker> workers { get; set; }
        public DbSet<Receipt> receipts { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>()
               .Property(a => a.Name)
               .IsRequired()
               .HasMaxLength(50);

            modelBuilder.Entity<Worker>()
               .Property(a => a.Surname)
               .IsRequired()
               .HasMaxLength(50);

            modelBuilder.Entity<Worker>()
               .Property(a => a.Login)
               .IsRequired()
               .HasMaxLength(50);

            modelBuilder.Entity<Worker>()
               .Property(a => a.Password)
               .IsRequired()
               .HasMaxLength(50);

            modelBuilder.Entity<Product>()
               .Property(a => a.Name)
               .IsRequired()
               .HasMaxLength(50);

            modelBuilder.Entity<Product>()
              .Property(a => a.Price)
              .IsRequired();

            modelBuilder.Entity<Product>()
              .Property(a => a.Count)
              .IsRequired();

            modelBuilder.Entity<Product>()
              .Property(a => a.isCountable)
              .IsRequired();

            modelBuilder.Entity<Product>()
              .Property(a => a.Vat)
              .IsRequired();

            modelBuilder.Entity<Receipt>()
              .Property(a => a.Number)
              .IsRequired();

            modelBuilder.Entity<Receipt>()
              .Property(a => a.Price)
              .IsRequired();

            modelBuilder.Entity<Invoice>()
              .Property(a => a.NIP)
              .IsRequired();

            modelBuilder.Entity<Invoice>()
              .Property(a => a.AccountNr)
              .IsRequired();

            modelBuilder.Entity<Invoice>()
              .Property(a => a.ClientName)
              .IsRequired()
              .HasMaxLength(50);

            modelBuilder.Entity<Order>()
             .Property(a => a.ClientName)
             .IsRequired()
             .HasMaxLength(50);

            modelBuilder.Entity<Order>()
             .Property(a => a.isInvoke)
             .IsRequired();

            modelBuilder
            .Entity<InvoiceProduct>()
            .HasKey(t => t.Id);

            modelBuilder
            .Entity<InvoiceProduct>()
            .HasOne(c => c.InvoiceMany)
            .WithMany(c => c.Products)
            .HasForeignKey(cl => cl.InvoiceId);

            modelBuilder
           .Entity<InvoiceProduct>()
           .HasOne(c => c.ProductMany)
           .WithMany(c => c.invoiceProducts)
           .HasForeignKey(cl => cl.ProductId);

            modelBuilder
            .Entity<ReceiptProduct>()
            .HasKey(t => t.Id);

            modelBuilder
            .Entity<ReceiptProduct>()
            .HasOne(c => c.ReceiptMany)
            .WithMany(c => c.Products)
            .HasForeignKey(cl => cl.ReceiptId);

            modelBuilder
           .Entity<ReceiptProduct>()
           .HasOne(c => c.ProductMany)
           .WithMany(c => c.receiptProducts)
           .HasForeignKey(cl => cl.ProductId);

            modelBuilder
           .Entity<OrderProduct>()
           .HasKey(t => t.Id);

            modelBuilder
            .Entity<OrderProduct>()
            .HasOne(c => c.OrderMany)
            .WithMany(c => c.Products)
            .HasForeignKey(cl => cl.OrderId);

            modelBuilder
           .Entity<OrderProduct>()
           .HasOne(c => c.ProductMany)
           .WithMany(c => c.Orders)
           .HasForeignKey(cl => cl.ProductId);
        }
    }
}
