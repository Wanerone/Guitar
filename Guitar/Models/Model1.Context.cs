﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Guitar.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GuitarEntities : DbContext
    {
        public GuitarEntities()
            : base("name=GuitarEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Friend> Friend { get; set; }
        public virtual DbSet<MusicScore> MusicScore { get; set; }
        public virtual DbSet<MusicScoreCollection> MusicScoreCollection { get; set; }
        public virtual DbSet<MusicScoreComment> MusicScoreComment { get; set; }
        public virtual DbSet<MusicScoreReply> MusicScoreReply { get; set; }
        public virtual DbSet<MusicScoreStatistics> MusicScoreStatistics { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<PostCollection> PostCollection { get; set; }
        public virtual DbSet<PostComment> PostComment { get; set; }
        public virtual DbSet<PostReply> PostReply { get; set; }
        public virtual DbSet<PostStatistics> PostStatistics { get; set; }
        public virtual DbSet<t_comment> t_comment { get; set; }
        public virtual DbSet<t_customer> t_customer { get; set; }
        public virtual DbSet<t_item> t_item { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Video> Video { get; set; }
        public virtual DbSet<VideoCollection> VideoCollection { get; set; }
        public virtual DbSet<VideoComment> VideoComment { get; set; }
        public virtual DbSet<VideoReply> VideoReply { get; set; }
        public virtual DbSet<VideoStatistics> VideoStatistics { get; set; }
    }
}
