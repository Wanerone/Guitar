//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class PostReply
    {
        public int Po_replyid { get; set; }
        public int Po_commentid { get; set; }
        public int Po_id { get; set; }
        public string content { get; set; }
        public System.DateTime Addtime { get; set; }
        public int User_id { get; set; }
    
        public virtual Post Post { get; set; }
        public virtual PostComment PostComment { get; set; }
        public virtual Users Users { get; set; }
    }
}
