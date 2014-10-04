using System.Data.Entity;
using MessangerFirst.Core.Model;

namespace MessangerFirst.Data
{
    /// <summary>
    /// Контекст база данных
    /// </summary>
    public class Db : DbContext
    {
        public DbSet<User> Users;
        public DbSet<Role> Roles;
        public DbSet<Message> Messages;

        /// <summary>
        /// Описание отношений таблиц при создании модели
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(r => r.Roles).WithMany(u => u.Users).Map(f =>
            {
                f.MapLeftKey("UserId");
                f.MapRightKey("RoleId");
            });

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Sender)
                .WithMany(t => t.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Reciever)
                .WithMany(t => t.ReceivedMessages)
                .HasForeignKey(m => m.RecieverId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

    }
}
