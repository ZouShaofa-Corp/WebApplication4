using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication4.Models
{
    public partial class imybContext : DbContext
    {
        public imybContext()
        {
        }

        public imybContext(DbContextOptions<imybContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountCategory> AccountCategory { get; set; }
        public virtual DbSet<AccountType> AccountType { get; set; }
        public virtual DbSet<AllSequences> AllSequences { get; set; }
        public virtual DbSet<ApplicationConfig> ApplicationConfig { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ErrorCategory> ErrorCategory { get; set; }
        public virtual DbSet<ErrorMessage> ErrorMessage { get; set; }
        public virtual DbSet<ErrorType> ErrorType { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<PurchaseHeader> PurchaseHeader { get; set; }
        public virtual DbSet<PurchaseLine> PurchaseLine { get; set; }
        public virtual DbSet<PurchasePayment> PurchasePayment { get; set; }
        public virtual DbSet<PurchasePaymentLine> PurchasePaymentLine { get; set; }
        public virtual DbSet<ReturnValueTable> ReturnValueTable { get; set; }
        public virtual DbSet<SalesHeader> SalesHeader { get; set; }
        public virtual DbSet<SalesLine> SalesLine { get; set; }
        public virtual DbSet<SalesReceipt> SalesReceipt { get; set; }
        public virtual DbSet<SalesReceiptLine> SalesReceiptLine { get; set; }
        public virtual DbSet<TransactionHeader> TransactionHeader { get; set; }
        public virtual DbSet<TransactionLine> TransactionLine { get; set; }
        public virtual DbSet<TransactionType> TransactionType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server= JoePC19\\SQLEXPRESS;Database=imyb;User ID=imyb;Password=pwdOne01;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.HasIndex(e => e.AccountName)
                    .HasName("account_name_idx")
                    .IsUnique();

                entity.HasIndex(e => e.AccountNumber)
                    .HasName("account_idx")
                    .IsUnique();

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AccountCategoryId).HasColumnName("account_category_id");

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasColumnName("account_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AccountNumber).HasColumnName("account_number");

                entity.Property(e => e.AccountTypeId).HasColumnName("account_type_id");

                entity.Property(e => e.Opening)
                    .HasColumnName("opening")
                    .HasColumnType("numeric(10, 2)");

                entity.HasOne(d => d.AccountCategory)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.AccountCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_account_account_category");

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.AccountTypeId)
                    .HasConstraintName("FK_account_account_type");
            });

            modelBuilder.Entity<AccountCategory>(entity =>
            {
                entity.ToTable("account_category");

                entity.Property(e => e.AccountCategoryId)
                    .HasColumnName("account_category_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountCategoryCode)
                    .HasColumnName("account_category_code")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.AccountCategoryLevel).HasColumnName("account_category_level");

                entity.Property(e => e.AccountCategoryName)
                    .HasColumnName("account_category_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AccountCategorySign)
                    .HasColumnName("account_category_sign")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ParentCategoryLevel).HasColumnName("parent_category_level");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.ToTable("account_type");

                entity.Property(e => e.AccountTypeId)
                    .HasColumnName("account_type_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountTypeName)
                    .HasColumnName("account_type_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AllSequences>(entity =>
            {
                entity.HasKey(e => e.SeqName)
                    .HasName("PK__AllSeque__9FBA12DC7F60ED59");

                entity.Property(e => e.SeqName).HasMaxLength(255);

                entity.Property(e => e.Incr).HasDefaultValueSql("((1))");

                entity.Property(e => e.Seed).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ApplicationConfig>(entity =>
            {
                entity.HasKey(e => e.ConfigName)
                    .HasName("PK__applicat__DACDDDEB300424B4");

                entity.ToTable("application_config");

                entity.Property(e => e.ConfigName)
                    .HasColumnName("config_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ConfigDescription)
                    .IsRequired()
                    .HasColumnName("config_description")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.ConfigItemSeq).HasColumnName("config_item_seq");

                entity.Property(e => e.ConfigValue)
                    .HasColumnName("config_value")
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.AddressLine1)
                    .HasColumnName("address_line1")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasColumnName("address_line2")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Closing)
                    .HasColumnName("closing")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.ContactName)
                    .HasColumnName("contact_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNotes)
                    .HasColumnName("contact_notes")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ContactType)
                    .HasColumnName("contact_type")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Opening)
                    .HasColumnName("opening")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Postcode).HasColumnName("postcode");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.TotalCr)
                    .HasColumnName("total_cr")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.TotalDr)
                    .HasColumnName("total_dr")
                    .HasColumnType("numeric(10, 2)");
            });

            modelBuilder.Entity<ErrorCategory>(entity =>
            {
                entity.ToTable("error_category");

                entity.Property(e => e.ErrorCategoryId).HasColumnName("error_category_id");

                entity.Property(e => e.ErrorCategoryDescription)
                    .HasColumnName("error_category_description")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorTypeId).HasColumnName("error_type_id");

                entity.HasOne(d => d.ErrorType)
                    .WithMany(p => p.ErrorCategory)
                    .HasForeignKey(d => d.ErrorTypeId)
                    .HasConstraintName("FK_error_type_category");
            });

            modelBuilder.Entity<ErrorMessage>(entity =>
            {
                entity.ToTable("error_message");

                entity.Property(e => e.ErrorMessageId).HasColumnName("error_message_id");

                entity.Property(e => e.CustomMessage)
                    .HasColumnName("custom_message")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ErrorCategoryId).HasColumnName("error_category_id");

                entity.Property(e => e.ErrorMessage1)
                    .HasColumnName("error_message")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.ErrorCategory)
                    .WithMany(p => p.ErrorMessage)
                    .HasForeignKey(d => d.ErrorCategoryId)
                    .HasConstraintName("FK_error_category_message");
            });

            modelBuilder.Entity<ErrorType>(entity =>
            {
                entity.ToTable("error_type");

                entity.Property(e => e.ErrorTypeId).HasColumnName("error_type_id");

                entity.Property(e => e.ErrorType1)
                    .HasColumnName("error_type")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item");

                entity.HasIndex(e => e.ItemName)
                    .HasName("IX_Item")
                    .IsUnique();

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.CostAccountId).HasColumnName("cost_account_id");

                entity.Property(e => e.InventoryAccountId).HasColumnName("inventory_account_id");

                entity.Property(e => e.ItemName)
                    .HasColumnName("item_name")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.OpeningAmount)
                    .HasColumnName("opening_amount")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.OpeningQty)
                    .HasColumnName("opening_qty")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.QtyOnHand)
                    .HasColumnName("qty_on_hand")
                    .HasColumnType("numeric(10, 2)")
                    .HasComment("Current quantity on hand");

                entity.Property(e => e.SalesPrice)
                    .HasColumnName("sales_price")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.TimeBilling).HasColumnName("time_billing");

                entity.Property(e => e.Unit)
                    .HasColumnName("unit")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CostAccount)
                    .WithMany(p => p.ItemCostAccount)
                    .HasForeignKey(d => d.CostAccountId)
                    .HasConstraintName("FK_item_account_cost");

                entity.HasOne(d => d.InventoryAccount)
                    .WithMany(p => p.ItemInventoryAccount)
                    .HasForeignKey(d => d.InventoryAccountId)
                    .HasConstraintName("FK_item_account_inventory");
            });

            modelBuilder.Entity<PurchaseHeader>(entity =>
            {
                entity.HasKey(e => e.PurchaseId)
                    .HasName("PK__purchase__87071CB947DBAE45");

                entity.ToTable("purchase_header");

                entity.Property(e => e.PurchaseId)
                    .HasColumnName("purchase_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.InvoiceNumber)
                    .IsRequired()
                    .HasColumnName("invoice_number")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Payment)
                    .HasColumnName("payment")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnName("purchase_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasColumnType("numeric(10, 2)");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.PurchaseHeader)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_purchase_header_contact");
            });

            modelBuilder.Entity<PurchaseLine>(entity =>
            {
                entity.HasKey(e => new { e.PurchaseId, e.PurchaseLineNumber })
                    .HasName("PK__purchase__0D0643F64CA06362");

                entity.ToTable("purchase_line");

                entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");

                entity.Property(e => e.PurchaseLineNumber)
                    .HasColumnName("purchase_line_number")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.PurchaseDescription)
                    .HasColumnName("purchase_description")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.PurchasePrice)
                    .HasColumnName("purchase_price")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasColumnType("numeric(10, 2)");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.PurchaseLine)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_purchase_line_item");

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.PurchaseLine)
                    .HasForeignKey(d => d.PurchaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_purchase_line_header");
            });

            modelBuilder.Entity<PurchasePayment>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__purchase__ED1FC9EA52593CB8");

                entity.ToTable("purchase_payment");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("payment_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaymentDescription)
                    .HasColumnName("payment_description")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.PurchasePayment)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_purchase_payment_account");
            });

            modelBuilder.Entity<PurchasePaymentLine>(entity =>
            {
                entity.HasKey(e => new { e.PaymentId, e.PaymentLineNumber })
                    .HasName("PK__purchase__B5C58B72571DF1D5");

                entity.ToTable("purchase_payment_line");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.PaymentLineNumber).HasColumnName("payment_line_number");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.PurchasePaymentLine)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_purchase_payment_line_purchase_payment");

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.PurchasePaymentLine)
                    .HasForeignKey(d => d.PurchaseId)
                    .HasConstraintName("FK_purchase_payment_line_purchase_header");
            });

            modelBuilder.Entity<ReturnValueTable>(entity =>
            {
                entity.ToTable("return_value_table");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReturnValue).HasColumnName("return_value");
            });

            modelBuilder.Entity<SalesHeader>(entity =>
            {
                entity.HasKey(e => e.SalesId)
                    .HasName("PK__Sales_he__995B85853C69FB99");

                entity.ToTable("Sales_header");

                entity.HasIndex(e => e.InvoiceNumber)
                    .HasName("IX_Sales_header")
                    .IsUnique();

                entity.Property(e => e.SalesId)
                    .HasColumnName("sales_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.InvoiceNumber)
                    .IsRequired()
                    .HasColumnName("invoice_number")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Payment)
                    .HasColumnName("payment")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.ReceiptId).HasColumnName("receipt_id");

                entity.Property(e => e.SalesDate)
                    .HasColumnName("sales_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.TransactionTypeId).HasColumnName("transaction_type_id");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.SalesHeader)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_Sales_header_contact");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.SalesHeader)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_header_transaction_type");
            });

            modelBuilder.Entity<SalesLine>(entity =>
            {
                entity.HasKey(e => new { e.SalesId, e.SalesLineNumber })
                    .HasName("PK__sales_li__977D95C05CD6CB2B");

                entity.ToTable("sales_line");

                entity.Property(e => e.SalesId).HasColumnName("sales_id");

                entity.Property(e => e.SalesLineNumber).HasColumnName("sales_line_number");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.SalesDescription)
                    .HasColumnName("sales_description")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Tax)
                    .HasColumnName("tax")
                    .HasColumnType("numeric(10, 2)");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.SalesLine)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_sales_line_account");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.SalesLine)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_sales_line_item");

                entity.HasOne(d => d.Sales)
                    .WithMany(p => p.SalesLine)
                    .HasForeignKey(d => d.SalesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sales_line_Sales_header");
            });

            modelBuilder.Entity<SalesReceipt>(entity =>
            {
                entity.HasKey(e => e.ReceiptId)
                    .HasName("PK__Sales_re__91F52C1F37A5467C");

                entity.ToTable("Sales_receipt");

                entity.Property(e => e.ReceiptId).HasColumnName("receipt_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.ReceiptDate)
                    .HasColumnName("receipt_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReceiptDescription)
                    .HasColumnName("receipt_description")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.SalesReceipt)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_receipt_account");
            });

            modelBuilder.Entity<SalesReceiptLine>(entity =>
            {
                entity.HasKey(e => new { e.ReceiptId, e.ReceiptLineNumber })
                    .HasName("PK__Sales_re__D9F823AC6383C8BA");

                entity.ToTable("Sales_receipt_line");

                entity.Property(e => e.ReceiptId).HasColumnName("receipt_id");

                entity.Property(e => e.ReceiptLineNumber).HasColumnName("receipt_line_number");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.SalesId).HasColumnName("sales_id");

                entity.HasOne(d => d.Receipt)
                    .WithMany(p => p.SalesReceiptLine)
                    .HasForeignKey(d => d.ReceiptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sales_receipt_line_Sales_receipt");

                entity.HasOne(d => d.Sales)
                    .WithMany(p => p.SalesReceiptLine)
                    .HasForeignKey(d => d.SalesId)
                    .HasConstraintName("FK_Sales_receipt_line_sales_header");
            });

            modelBuilder.Entity<TransactionHeader>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PK__transact__85C600AF25869641");

                entity.ToTable("transaction_header");

                entity.Property(e => e.TransactionId)
                    .HasColumnName("transaction_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenceId).HasColumnName("reference_id");

                entity.Property(e => e.TransactionDate)
                    .HasColumnName("transaction_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TransactionTypeId).HasColumnName("transaction_type_id");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.TransactionHeader)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .HasConstraintName("FK_transaction_header_transaction_type");
            });

            modelBuilder.Entity<TransactionLine>(entity =>
            {
                entity.HasKey(e => new { e.TransactionId, e.TransactionLineId })
                    .HasName("PK__transact__F8BFBFE02A4B4B5E");

                entity.ToTable("transaction_line");

                entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

                entity.Property(e => e.TransactionLineId).HasColumnName("transaction_line_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AccountSign)
                    .IsRequired()
                    .HasColumnName("account_sign")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("numeric(10, 2)");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TransactionLine)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_transaction_line_account");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TransactionLine)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_transaction_line_transaction_header");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("transaction_type");

                entity.Property(e => e.TransactionTypeId)
                    .HasColumnName("transaction_type_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.TransactionTypeDescription)
                    .HasColumnName("transaction_type_description")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
