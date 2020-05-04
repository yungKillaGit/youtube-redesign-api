
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Youtube.Api.Infrastructure.Data.Entities;

namespace Youtube.Api.Infrastructure.Data
{
    public partial class YoutubeContext : DbContext
    {
        public YoutubeContext()
        {
        }

        public YoutubeContext(DbContextOptions<YoutubeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChannelSubscriber> ChannelSubscribers { get; set; }
        public virtual DbSet<Channel> Channels { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<ProfilePicture> ProfilePictures { get; set; }
        public virtual DbSet<SectionedVideo> SectionedVideos { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<UploadedFile> UploadedFiles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Video> Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=youtube;Username=postgres;Password=password");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChannelSubscriber>(entity =>
            {
                entity.ToTable("channelSubscribers");

                entity.HasIndex(e => new { e.ChannelId, e.UserId })
                    .HasName("channelSubscribers_channelId_userId_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ChannelId).HasColumnName("channelId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.ChannelSubscribers)
                    .HasForeignKey(d => d.ChannelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("channelSubscribers_channelId_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ChannelSubscribers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("channelSubscribers_userId_fkey");
            });

            modelBuilder.Entity<Channel>(entity =>
            {
                entity.ToTable("channels");

                entity.HasIndex(e => e.UserId)
                    .HasName("channels_userId_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnName("registrationDate")
                    .HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Channels)
                    .HasForeignKey<Channel>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("channels_userId_fkey");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comments");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.PostingDate).HasColumnName("postingDate");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.VideoId).HasColumnName("videoId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comments_userId_fkey");

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.VideoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("comments_videoId_fkey");
            });

            modelBuilder.Entity<ProfilePicture>(entity =>
            {
                entity.ToTable("profilePictures");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.ProfilePictures)
                    .HasForeignKey<ProfilePicture>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("profilePictures_id_fkey");
            });

            modelBuilder.Entity<SectionedVideo>(entity =>
            {
                entity.ToTable("sectionedVideos");

                entity.HasIndex(e => new { e.UserId, e.VideoId, e.SectionId })
                    .HasName("sectionedVideos_userId_videoId_sectionId_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.SectionId).HasColumnName("sectionId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.VideoId).HasColumnName("videoId");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.SectionedVideos)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sectionedVideos_sectionId_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SectionedVideos)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sectionedVideos_userId_fkey");

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.SectionedVideos)
                    .HasForeignKey(d => d.VideoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sectionedVideos_videoId_fkey");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("sections");

                entity.HasIndex(e => e.Name)
                    .HasName("sections_name_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<UploadedFile>(entity =>
            {
                entity.ToTable("uploadedFiles");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.FileExtension)
                    .IsRequired()
                    .HasColumnName("fileExtension");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("fileName");

                entity.Property(e => e.RelativePath)
                    .IsRequired()
                    .HasColumnName("relativePath");

                entity.Property(e => e.UploadDate).HasColumnName("uploadDate");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UploadedFiles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("uploadedFiles_userId_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("users_email_key")
                    .IsUnique();

                entity.HasIndex(e => e.PasswordHash)
                    .HasName("users_passwordHash_key");                    

                entity.HasIndex(e => e.ProfilePictureId)
                    .HasName("users_profilePictureId_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.BirthDay)
                    .HasColumnName("birthDay")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasColumnName("passwordHash");

                entity.Property(e => e.ProfilePictureId).HasColumnName("profilePictureId");

                entity.HasOne(d => d.ProfilePicture)
                    .WithOne(p => p.Users)
                    .HasForeignKey<User>(d => d.ProfilePictureId)
                    .HasConstraintName("users_profilePictureId_fkey");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.ToTable("videos");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Dislikes).HasColumnName("dislikes");

                entity.Property(e => e.Likes).HasColumnName("likes");

                entity.Property(e => e.Views).HasColumnName("views");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Videos)
                    .HasForeignKey<Video>(d => d.Id)
                    .HasConstraintName("videos_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
