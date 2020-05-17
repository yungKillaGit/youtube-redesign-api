using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Youtube.Api.Infrastructure.Data.Entities;

namespace Youtube.Api.Infrastructure.Data.EntityFramework
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
        public virtual DbSet<Image> Images { get; set; }
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

                entity.HasIndex(e => e.Name)
                    .HasName("channels_name_key")
                    .IsUnique();

                entity.HasIndex(e => e.UserId)
                    .HasName("channels_userId_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnName("registrationDate")
                    .HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Channel)
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
                    .HasConstraintName("comments_videoId_fkey");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("images");

                entity.HasIndex(e => e.UploadedFileId)
                    .HasName("images_uploadedFileId_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.EncodedImage)
                    .IsRequired()
                    .HasColumnName("encodedImage");

                entity.Property(e => e.ContentType)
                    .IsRequired()
                    .HasColumnName("contentType");

                entity.Property(e => e.UploadedFileId).HasColumnName("uploadedFileId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.UploadedFile)
                    .WithOne(p => p.Image)
                    .HasForeignKey<Image>(d => d.UploadedFileId)
                    .HasConstraintName("images_uploadedFileId_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("images_userId_fkey");
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

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("fileName");

                entity.Property(e => e.RelativePath)
                    .IsRequired()
                    .HasColumnName("relativePath");

                entity.Property(e => e.UploadDate).HasColumnName("uploadDate");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("users_email_key")
                    .IsUnique();

                entity.HasIndex(e => e.ImageId)
                    .HasName("users_imageId_key")
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

                entity.Property(e => e.ImageId).HasColumnName("imageId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasColumnName("passwordHash");

                entity.HasOne(d => d.Image)
                    .WithOne(p => p.Users)
                    .HasForeignKey<User>(d => d.ImageId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("users_imageId_fkey");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.ToTable("videos");

                entity.HasIndex(e => e.PreviewImageId)
                    .HasName("videos_previewImageId_key")
                    .IsUnique();

                entity.HasIndex(e => e.UploadedFileId)
                    .HasName("videos_uploadedFileId_key")
                    .IsUnique();

                entity.HasIndex(e => new { e.UploadedFileId, e.PreviewImageId })
                    .HasName("videos_uploadedFileId_previewImageId_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Dislikes).HasColumnName("dislikes");

                entity.Property(e => e.Likes).HasColumnName("likes");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.PreviewImageId).HasColumnName("previewImageId");

                entity.Property(e => e.UploadedFileId).HasColumnName("uploadedFileId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Views).HasColumnName("views");

                entity.HasOne(d => d.PreviewImage)
                    .WithOne(p => p.Video)
                    .HasForeignKey<Video>(d => d.PreviewImageId)
                    .HasConstraintName("videos_previewImageId_fkey");

                entity.HasOne(d => d.UploadedFile)
                    .WithOne(p => p.Video)
                    .HasForeignKey<Video>(d => d.UploadedFileId)
                    .HasConstraintName("videos_uploadedFileId_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("videos_userId_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
