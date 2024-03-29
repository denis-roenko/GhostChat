﻿// <auto-generated />
using System;
using GhostChat.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GhostChat.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("GhostChat.Data.Models.Friendship", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AcceptingUserId");

                    b.Property<bool>("AreFriends");

                    b.Property<Guid?>("RequestingUserId");

                    b.HasKey("Id");

                    b.HasIndex("AcceptingUserId");

                    b.HasIndex("RequestingUserId");

                    b.ToTable("Friendships");
                });

            modelBuilder.Entity("GhostChat.Data.Models.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<Guid?>("SenderId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("GhostChat.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GhostChat.Data.Models.UserMessage", b =>
                {
                    b.Property<Guid>("MessageId");

                    b.Property<Guid>("UserID");

                    b.HasKey("MessageId", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("UserMessages");
                });

            modelBuilder.Entity("GhostChat.Data.Models.Friendship", b =>
                {
                    b.HasOne("GhostChat.Data.Models.User", "AcceptingUser")
                        .WithMany()
                        .HasForeignKey("AcceptingUserId");

                    b.HasOne("GhostChat.Data.Models.User", "RequestingUser")
                        .WithMany()
                        .HasForeignKey("RequestingUserId");
                });

            modelBuilder.Entity("GhostChat.Data.Models.Message", b =>
                {
                    b.HasOne("GhostChat.Data.Models.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");
                });

            modelBuilder.Entity("GhostChat.Data.Models.UserMessage", b =>
                {
                    b.HasOne("GhostChat.Data.Models.Message", "Message")
                        .WithMany("UserMessages")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GhostChat.Data.Models.User", "User")
                        .WithMany("UserMessages")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
