using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SmartOffice.DataLayer.MasterDBContext
{
    public partial class MasterDBContext : DbContext
    {
        public MasterDBContext()
        {
        }

        public MasterDBContext(DbContextOptions<MasterDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Configdatamanager> Configdatamanager { get; set; }
        public virtual DbSet<Configlov> Configlov { get; set; }
        public virtual DbSet<Configsubscription> Configsubscription { get; set; }
        public virtual DbSet<Masacgroup> Masacgroup { get; set; }
        public virtual DbSet<Masacmaster> Masacmaster { get; set; }
        public virtual DbSet<Masaddress> Masaddress { get; set; }
        public virtual DbSet<Masbranch> Masbranch { get; set; }
        public virtual DbSet<Masbusiness> Masbusiness { get; set; }
        public virtual DbSet<Masemployee> Masemployee { get; set; }
        public virtual DbSet<Masfacility> Masfacility { get; set; }
        public virtual DbSet<Massalarygroup> Massalarygroup { get; set; }
        public virtual DbSet<Masshift> Masshift { get; set; }
        public virtual DbSet<Masslot> Masslot { get; set; }
        public virtual DbSet<Masuser> Masuser { get; set; }
        public virtual DbSet<Trnattendance> Trnattendance { get; set; }
        public virtual DbSet<Trnledger> Trnledger { get; set; }
        public virtual DbSet<Trnsalarydetails> Trnsalarydetails { get; set; }
        public virtual DbSet<Trnsalaryheader> Trnsalaryheader { get; set; }
        public virtual DbSet<Trnslotbooking> Trnslotbooking { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;database=sample1;user id=root;password=Admin@123;port=3307;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Configdatamanager>(entity =>
            {
                entity.HasKey(e => e.CdId)
                    .HasName("PRIMARY");

                entity.ToTable("configdatamanager");

                entity.Property(e => e.Bid).HasColumnName("BId");

                entity.Property(e => e.CdIsactive).HasDefaultValueSql("'1'");

                entity.Property(e => e.CdKeyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CdValue)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Configlov>(entity =>
            {
                entity.HasKey(e => e.ClId)
                    .HasName("PRIMARY");

                entity.ToTable("configlov");

                entity.Property(e => e.ClIsactive).HasDefaultValueSql("'1'");

                entity.Property(e => e.ClLovcode)
                    .IsRequired()
                    .HasColumnName("ClLOVCode")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ClLovname)
                    .IsRequired()
                    .HasColumnName("ClLOVName")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ClLovtype)
                    .IsRequired()
                    .HasColumnName("ClLOVType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Configsubscription>(entity =>
            {
                entity.HasKey(e => e.CsId)
                    .HasName("PRIMARY");

                entity.ToTable("configsubscription");

                entity.Property(e => e.ClLovname)
                    .IsRequired()
                    .HasColumnName("ClLOVName")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CsIsactive).HasDefaultValueSql("'1'");

                entity.Property(e => e.CsName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CsValue).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Masacgroup>(entity =>
            {
                entity.HasKey(e => e.AcgId)
                    .HasName("PRIMARY");

                entity.ToTable("masacgroup");

                entity.Property(e => e.AcgGroupName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.AcgIsactive).HasDefaultValueSql("'1'");

                entity.Property(e => e.Bid).HasColumnName("BId");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Masacmaster>(entity =>
            {
                entity.HasKey(e => e.AcId)
                    .HasName("PRIMARY");

                entity.ToTable("masacmaster");

                entity.Property(e => e.AcIsactive).HasDefaultValueSql("'1'");

                entity.Property(e => e.AcName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.AcheadCode).HasColumnName("ACHeadCode");

                entity.Property(e => e.Bid).HasColumnName("BId");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Masaddress>(entity =>
            {
                entity.HasKey(e => e.AddId)
                    .HasName("PRIMARY");

                entity.ToTable("masaddress");

                entity.Property(e => e.AddArea)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.AddCity)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddDoorNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AddIsactive).HasDefaultValueSql("'1'");

                entity.Property(e => e.AddLandmark)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.AddPin)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.AddStreetName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Masbranch>(entity =>
            {
                entity.HasKey(e => e.BrId)
                    .HasName("PRIMARY");

                entity.ToTable("masbranch");

                entity.Property(e => e.Bid).HasColumnName("BId");

                entity.Property(e => e.BrContactNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.BrEmailId)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.BrIsactive).HasDefaultValueSql("'1'");

                entity.Property(e => e.BrName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Masbusiness>(entity =>
            {
                entity.HasKey(e => e.Bid)
                    .HasName("PRIMARY");

                entity.ToTable("masbusiness");

                entity.Property(e => e.Bid).HasColumnName("BId");

                entity.Property(e => e.BaccountStartDate)
                    .HasColumnName("BAccountStartDate")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Bemail)
                    .IsRequired()
                    .HasColumnName("BEmail")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Bisactive)
                    .HasColumnName("BIsactive")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Blogo)
                    .IsRequired()
                    .HasColumnName("BLogo")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Bname)
                    .IsRequired()
                    .HasColumnName("BName")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Bphone1)
                    .IsRequired()
                    .HasColumnName("BPhone1")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Bphone2)
                    .IsRequired()
                    .HasColumnName("BPhone2")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Bwebsite)
                    .IsRequired()
                    .HasColumnName("BWebsite")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.BweeklyHolyday)
                    .HasColumnName("BWeeklyHolyday")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Masemployee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PRIMARY");

                entity.ToTable("masemployee");

                entity.Property(e => e.Bid).HasColumnName("BId");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.EmpAltContactNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EmpBankAcNo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EmpBankBranch)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EmpBankName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EmpBasicSalary).HasColumnType("decimal(18,2)");

                entity.Property(e => e.EmpBeneficiaryName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EmpCode)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EmpContactNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EmpEmail)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.EmpIfsccode)
                    .IsRequired()
                    .HasColumnName("EmpIFSCCode")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.EmpIsactive).HasDefaultValueSql("'1'");

                entity.Property(e => e.EmpLeaveAllowdMonth).HasColumnType("decimal(10,2)");

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmpPanno)
                    .IsRequired()
                    .HasColumnName("EmpPANNo")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EmpSalaryType)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.EmpUid)
                    .HasColumnName("EmpUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Masfacility>(entity =>
            {
                entity.HasKey(e => e.FaId)
                    .HasName("PRIMARY");

                entity.ToTable("masfacility");

                entity.Property(e => e.Bid).HasColumnName("BId");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.FaIsactive).HasDefaultValueSql("'1'");

                entity.Property(e => e.FaName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Massalarygroup>(entity =>
            {
                entity.HasKey(e => e.SgId)
                    .HasName("PRIMARY");

                entity.ToTable("massalarygroup");

                entity.Property(e => e.Bid).HasColumnName("BId");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.SgFormula)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SgIsactive).HasDefaultValueSql("'1'");

                entity.Property(e => e.SgName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SgType)
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Masshift>(entity =>
            {
                entity.HasKey(e => e.ShId)
                    .HasName("PRIMARY");

                entity.ToTable("masshift");

                entity.Property(e => e.Bid).HasColumnName("BId");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ShIsactive).HasDefaultValueSql("'1'");

                entity.Property(e => e.ShName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Masslot>(entity =>
            {
                entity.HasKey(e => e.SlId)
                    .HasName("PRIMARY");

                entity.ToTable("masslot");

                entity.Property(e => e.Bid).HasColumnName("BId");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.SlFacility)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SlIsactive).HasDefaultValueSql("'1'");

                entity.Property(e => e.SlName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Masuser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("masuser");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UserEmailId)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UserIsactive).HasDefaultValueSql("'1'");

                entity.Property(e => e.UserLoginId)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UserMobile)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Trnattendance>(entity =>
            {
                entity.HasKey(e => e.AttId)
                    .HasName("PRIMARY");

                entity.ToTable("trnattendance");

                entity.Property(e => e.AttAttendance)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AttIsactive).HasDefaultValueSql("'1'");

                entity.Property(e => e.AttLateFee).HasColumnType("decimal(18,2)");

                entity.Property(e => e.AttOtamount)
                    .HasColumnName("AttOTAmount")
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.AttOthour)
                    .HasColumnName("AttOTHour")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Bid).HasColumnName("BId");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Trnledger>(entity =>
            {
                entity.HasKey(e => e.LedId)
                    .HasName("PRIMARY");

                entity.ToTable("trnledger");

                entity.Property(e => e.Bid).HasColumnName("BId");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.LedCredit).HasColumnType("decimal(18,2)");

                entity.Property(e => e.LedDddate)
                    .IsRequired()
                    .HasColumnName("LedDDDate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LedDdno)
                    .IsRequired()
                    .HasColumnName("LedDDNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LedDebit).HasColumnType("decimal(18,2)");

                entity.Property(e => e.LedIsactive).HasDefaultValueSql("'1'");

                entity.Property(e => e.LedNotes)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LedRefNo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LedVouSno).HasColumnName("LedVouSNo");

                entity.Property(e => e.LedVoucherType)
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Trnsalarydetails>(entity =>
            {
                entity.HasKey(e => e.TsdId)
                    .HasName("PRIMARY");

                entity.ToTable("trnsalarydetails");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.TsdAmount).HasColumnType("decimal(18,2)");

                entity.Property(e => e.TsdDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TsdIsactive).HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<Trnsalaryheader>(entity =>
            {
                entity.HasKey(e => e.TsId)
                    .HasName("PRIMARY");

                entity.ToTable("trnsalaryheader");

                entity.Property(e => e.Bid).HasColumnName("BId");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.TsDeduction).HasColumnType("decimal(18,2)");

                entity.Property(e => e.TsGrossSalary).HasColumnType("decimal(18,2)");

                entity.Property(e => e.TsIsActive).HasDefaultValueSql("'1'");

                entity.Property(e => e.TsLop).HasColumnName("TsLOP");

                entity.Property(e => e.TsMonthYear)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.TsNetSalary).HasColumnType("decimal(18,2)");

                entity.Property(e => e.TsPayMode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Trnslotbooking>(entity =>
            {
                entity.HasKey(e => e.SbId)
                    .HasName("PRIMARY");

                entity.ToTable("trnslotbooking");

                entity.Property(e => e.SbId).HasColumnName("sbId");

                entity.Property(e => e.Bid).HasColumnName("BId");

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("'1'");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.SbExtraFacility)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.SbIsactive).HasDefaultValueSql("'1'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
